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
                if (coll != null) {
                    Debug.Log("ChooseEntity: " + coll.name);
                    // Role
                    RoleEntity role = coll.GetComponentInParent<RoleEntity>();
                    if (role != null) {
                        ctx.playerEntity.chosenEntityType = role.entityType;
                        ctx.playerEntity.chosenEntityID = role.id;
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