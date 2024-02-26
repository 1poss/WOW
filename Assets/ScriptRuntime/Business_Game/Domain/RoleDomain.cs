using UnityEngine;

namespace WOW.Business {

    public static class RoleDomain {

        public static RoleEntity Spawn(GameContext ctx, int typeID, AllyType allyType, Vector2 pos) {
            RoleEntity role = GameFactory.Role_Create(ctx.templates, ctx.idService, typeID, allyType, pos);
            role.fsm.Normal_Enter();
            ctx.roleRepository.Add(role);
            return role;
        }

        public static void MoveByPath(GameContext ctx, RoleEntity role, float fixdt) {
            role.Move_ByClickTick(fixdt);
        }

        public static void TryCast(GameContext ctx, RoleEntity role) {
            if (role.commandComponent.isSkillDown) {
                bool has = role.skillSlotComponent.TryGet(role.commandComponent.castingSkillKey, out var skill);
                if (!has) {
                    return;
                }
                Cast(ctx, role, skill.typeID);
            }
        }

        public static void Cast(GameContext ctx, RoleEntity role, int skillTypeID) {

            bool has = role.skillSlotComponent.TryGetByTypeID(skillTypeID, out var skill);
            if (!has) {
                return;
            }

            // TODO: Allow
            if (skill.cdTimer > 0) {
                return;
            }

            if (skill.indicateType == SkillIndicateType.None) {
                role.fsm.Casting_Enter(skill);
            }

        }

        public static void SkillAct(GameContext ctx, RoleEntity role) {

        }

    }
}