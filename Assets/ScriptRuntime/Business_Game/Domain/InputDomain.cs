using System;
using UnityEngine;
using GameFunctions;

namespace WOW.Business {

    public static class InputDomain {

        public static void Process(GameContext ctx, InputEntity input) {
            input.Process();

            var cam = ctx.cameraCore.mainCamera;

            Vector3 worldPos = cam.ScreenToWorldPoint(ctx.inputEntity.downScreenPos);
            ctx.inputEntity.downWorldPos = worldPos;

            KeySelecting(ctx, input);
            MouseSelecting(ctx, input);
            MouseMoving(ctx, input);
        }

        static void KeySelecting(GameContext ctx, InputEntity input) {
            if (!input.isChooseDown) {
                return;
            }
            RoleEntity chosenRole = ctx.roleRepository.GetPlayerTeamer(input.chosenChoose.ToChosenTeamerIndex());
            if (chosenRole != null) {
                CancelChosen(ctx);
                ctx.playerEntity.chosenEntityType = EntityType.Role;
                ctx.playerEntity.chosenEntityID = chosenRole.id;
                chosenRole.SR_Chosen(true);
                Debug.Log($"Chosen: {chosenRole.id}");
            }
        }

        static void MouseSelecting(GameContext ctx, InputEntity input) {
            if (input.isLeftDown) {
                Collider2D coll = Physics2D.OverlapPoint(input.downWorldPos);
                CancelChosen(ctx);
                if (coll != null) {
                    // Role
                    RoleEntity role = coll.GetComponentInParent<RoleEntity>();
                    if (role != null && role.allyType == AllyType.Player) {
                        ctx.playerEntity.chosenEntityType = role.entityType;
                        ctx.playerEntity.chosenEntityID = role.id;
                        role.SR_Chosen(true);
                        return;
                    }
                }
                ctx.playerEntity.chosenEntityType = EntityType.None;
            }
        }

        static void MouseMoving(GameContext ctx, InputEntity input) {
            if (input.isRightDown) {
                int id = ctx.playerEntity.chosenEntityID;
                if (ctx.playerEntity.chosenEntityType == EntityType.Role) {
                    bool has = ctx.roleRepository.TryGet(id, out var role);
                    if (role != null) {
                        role.Move_Start(input.downWorldPos);
                    }
                }
            }
        }

        static void CancelChosen(GameContext ctx) {
            var player = ctx.playerEntity;
            if (player.chosenEntityType == EntityType.Role) {
                bool has = ctx.roleRepository.TryGet(player.chosenEntityID, out var last);
                if (last != null) {
                    last.SR_Chosen(false);
                }
            }
            player.chosenEntityType = EntityType.None;
        }

    }

}