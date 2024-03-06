namespace WOW {

    public class RoleFSMComponent {

        public RoleFSMStatus status;

        public bool normal_isEntering;

        public bool casting_isEntering;
        public SkillSubentity casting_skill;
        public SkillStage casting_stage;
        public EntityType casting_targetType;
        public int casting_targetID;
        public float casting_preTimer;
        public float casting_actTimer;
        public float casting_actIntervalTimer;
        public float casting_postTimer;

        public void Normal_Enter() {
            status = RoleFSMStatus.Normal;
            normal_isEntering = true;
        }

        public void Casting_Enter(SkillSubentity skill, EntityType targetType, int targetID) {
            status = RoleFSMStatus.Casting;
            casting_isEntering = true;
            casting_skill = skill;
            casting_targetType = targetType;
            casting_targetID = targetID;
            casting_stage = SkillStage.Pre;
            casting_preTimer = skill.preSec;
            casting_actTimer = skill.actSec;
            casting_actIntervalTimer = skill.actInterval;
            casting_postTimer = skill.postSec;
        }

    }

}