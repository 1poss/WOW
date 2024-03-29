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

            TryCancelChoose(ctx, input);
            KeySelecting(ctx, input);
            MouseSelecting(ctx, input);
            MouseMoving(ctx, input);
            ChosenCast(ctx);

        }

        static void TryCancelChoose(GameContext ctx, InputEntity input) {
            if (!input.isCancelDown) {
                return;
            }
            CancelChosen(ctx);
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
                if (ctx.TryGetChosenRole(out var role)) {
                    role.aiComponent.CancelAutoMeleeTarget();
                    if (role.fsm.status == RoleFSMStatus.Casting && role.fsm.casting_skill.skillType == SkillType.Melee) {
                        role.fsm.Normal_Enter();
                    }
                    role.Move_Start(input.downWorldPos);
                }
            }
        }

        static void CancelChosen(GameContext ctx) {
            if (ctx.TryGetChosenRole(out var role)) {
                role.SR_Chosen(false);
            }
            var player = ctx.playerEntity;
            player.chosenEntityType = EntityType.None;
        }

        static void ChosenCast(GameContext ctx) {
            bool isChosen = ctx.TryGetChosenRole(out var chosenRole);
            if (isChosen) {
                var input = ctx.inputEntity;
                chosenRole.commandComponent.RecordCast(input.isSkillDown, input.chosenSkillKey);
            }
        }

    }

}