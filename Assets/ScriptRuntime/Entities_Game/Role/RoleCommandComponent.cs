namespace WOW {

    public class RoleCommandComponent {

        public bool isSkillDown;
        public InputEnum castingSkillKey;

        public RoleCommandComponent() {
            isSkillDown = false;
            castingSkillKey = 0;
        }

        public void RecordCast(bool isSkillDown, InputEnum skillKey) {
            this.isSkillDown = isSkillDown;
            castingSkillKey = skillKey;
        }

    }

}