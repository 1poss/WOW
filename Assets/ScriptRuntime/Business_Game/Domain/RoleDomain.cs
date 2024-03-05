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

            EntityType targetEntityType = EntityType.None;
            int targetEntityID = 0;
            if (skill.castDirection == SkillCastDirection.Trace) {
                RoleEntity target = ctx.roleRepository.TryFindNearest(role.Pos_Pos(), skill.castRange);
                if (target != null) {
                    targetEntityType = target.entityType;
                    targetEntityID = target.id;
                }
            }
            role.fsm.Casting_Enter(skill, targetEntityType, targetEntityID);

        }

        public static void SkillAct(GameContext ctx, RoleEntity caster, SkillSubentity skill) {

            if (skill.hasSpawnBullet) {
                // TODO: SpawnBullet
            }

            if (skill.hasActCollider) {

                // Act Effector

                // Act Overlap
                Vector2 startPos = caster.transform.position + (caster.transform.rotation * skill.actColliderOffset);
                if (skill.actColliderShape == ShapeType.Point) {
                    // Find one
                    RoleEntity victim = ctx.roleRepository.TryFindNearest(startPos, skill.castRange);
                    if (victim != null && victim != caster) {
                        SkillHitRole(ctx, caster, skill, victim);
                    }
                }

                Collider2D[] colliders = null;
                if (skill.actColliderShape == ShapeType.Rect) {
                    colliders = Physics2D.OverlapBoxAll(startPos, skill.actColliderSize, 0);
                } else if (skill.actColliderShape == ShapeType.Circle) {
                    colliders = Physics2D.OverlapCircleAll(startPos, skill.actColliderSize.x);
                }
                if (colliders != null) {
                    for (int i = 0; i < colliders.Length; i++) {
                        var other = colliders[i];
                        var victim = other.GetComponentInParent<RoleEntity>();
                        if (victim != null && victim != caster) {
                            SkillHitRole(ctx, caster, skill, victim);
                        }
                    }
                }

            }

        }

        static void SkillHitRole(GameContext ctx, RoleEntity caster, SkillSubentity skill, RoleEntity victim) {
            Debug.Log($"SkillHitRole: {caster.name} -> {victim.name}");
            if (skill.hasHitEffector) {
                victim.attrComponent.hp -= skill.hitEffector.instantDamage;
            }
        }

    }
}