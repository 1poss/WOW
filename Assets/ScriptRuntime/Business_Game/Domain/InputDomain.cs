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

            Selecting(ctx, input);
            Moving(ctx, input);
        }

        static void Selecting(GameContext ctx, InputEntity input) {
            if (input.isLeftDown) {
                Collider2D coll = Physics2D.OverlapPoint(input.downWorldPos);
                var player = ctx.playerEntity;
                if (player.chosenEntityType == EntityType.Role) {
                    bool has = ctx.roleRepository.TryGet(player.chosenEntityID, out var last);
                    if (last != null) {
                        last.SR_Chosen(false);
                    }
                }
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

        static void Moving(GameContext ctx, InputEntity input) {
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

    }

}