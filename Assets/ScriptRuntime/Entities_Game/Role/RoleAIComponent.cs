using UnityEngine;

namespace WOW {

    public class RoleAIComponent {

        public float meleeSearchRange;

        public EntityType autoMeleeTargetType;
        public int autoMeleeTargetID;

        public RoleAIComponent() { }

        public void CancelAutoMeleeTarget() {
            autoMeleeTargetType = EntityType.None;
            autoMeleeTargetID = 0;
        }

    }

}