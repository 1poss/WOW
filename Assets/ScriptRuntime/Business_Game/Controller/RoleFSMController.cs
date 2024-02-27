namespace WOW.Business {

    public static class RoleFSMController {

        public static void FixedTick(GameContext ctx, RoleEntity role, float fixdt) {
            RoleFSMStatus status = role.fsm.status;
            if (status == RoleFSMStatus.Normal) {
                Normal_FixTick(ctx, role, fixdt);
            } else if (status == RoleFSMStatus.Casting) {
                Casting_FixTick(ctx, role, fixdt);
            }
        }

        static void Normal_FixTick(GameContext ctx, RoleEntity role, float fixdt) {
            if (role.fsm.normal_isEntering) {
                role.fsm.normal_isEntering = false;
            }
            RoleDomain.MoveByPath(ctx, role, fixdt);
            RoleDomain.TryCast(ctx, role);
        }

        static void Casting_FixTick(GameContext ctx, RoleEntity role, float fixdt) {

            if (role.fsm.casting_isEntering) {
                role.fsm.casting_isEntering = false;
                role.mod.Param_TriggerCast();
                role.Move_Stop();
            }

            RoleFSMComponent fsm = role.fsm;
            SkillSubentity skill = fsm.casting_skill;
            ref SkillStage stage = ref fsm.casting_stage;
            if (stage == SkillStage.Pre) {
                // 前摇
                if (fsm.casting_preTimer > 0) {
                    fsm.casting_preTimer -= fixdt;
                } else {
                    stage = SkillStage.Act;
                }
            } else if (stage == SkillStage.Act) {
                // 生效
                ref float actTimer = ref fsm.casting_actTimer;
                if (actTimer > 0) {
                    actTimer -= fixdt;
                    // 多次生效
                    ref float actIntervalTimer = ref fsm.casting_actIntervalTimer;
                    if (actIntervalTimer > 0) {
                        actIntervalTimer -= fixdt;
                    }
                    if (actIntervalTimer <= 0) {
                        actIntervalTimer += skill.actInterval;
                        RoleDomain.SkillAct(ctx, role, skill);
                    }
                } else {
                    stage = SkillStage.Post;
                }
            } else if (stage == SkillStage.Post) {
                // 后摇
                if (fsm.casting_postTimer > 0) {
                    fsm.casting_postTimer -= fixdt;
                } else {
                    fsm.Normal_Enter();
                }
            }

        }

    }

}