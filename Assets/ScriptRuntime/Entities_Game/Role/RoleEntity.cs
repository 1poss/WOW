using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;
        public AllyType allyType;

        [SerializeField] public Transform body;
        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;
        [SerializeField] SpriteRenderer chosenSR;
        [SerializeField] LineRenderer lr;

        public RoleMod mod;

        public bool isReachTarget;
        public Vector2 targetPos;
        public float moveSpeed;

        public RoleSkillSlotComponent skillSlotComponent;

        public void Ctor() {
            moveSpeed = 5;
            isReachTarget = true;
            chosenSR.enabled = false;

            skillSlotComponent = new RoleSkillSlotComponent();
        }

        public Vector2Int Pos_PosInt() {
            return new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        public void Pos_Set(Vector2 pos) {
            transform.position = pos;
        }

        public void Move_Start(Vector2 targetPos) {
            this.targetPos = targetPos;
            this.isReachTarget = false;
            lr.positionCount = 2;
        }

        public void Move_FixTick(float fixdt) {

            if (isReachTarget) {
                lr.enabled = false;
                mod.Param_SetMagnitude(0);
                return;
            }

            lr.enabled = true;

            Vector2 curPos = transform.position;
            float moveSpeedDTSqr = moveSpeed * fixdt * moveSpeed;
            Vector2 dir = targetPos - curPos;
            if (dir.sqrMagnitude <= moveSpeedDTSqr) {
                rb.MovePosition(targetPos);
                isReachTarget = true;
            } else {
                Vector2 nextPos = curPos + dir.normalized * moveSpeed * fixdt;
                rb.MovePosition(nextPos);
            }

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPos);

            mod.Param_SetMagnitude(1);

            if (dir.x > 0) {
                body.localScale = new Vector3(-1, 1, 1);
            } else if (dir.x < 0) {
                body.localScale = new Vector3(1, 1, 1);
            }

        }

        public void SR_Chosen(bool chosen) {
            chosenSR.enabled = chosen;
        }

    }

}