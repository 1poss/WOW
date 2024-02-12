using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

        public bool isReachTarget;
        public Vector2 targetPos;
        public float moveSpeed;

        public void Ctor() {
            moveSpeed = 5;
        }

        public Vector2Int Pos_PosInt() {
            return new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        public void Move_Start(Vector2 targetPos) {
            this.targetPos = targetPos;
            this.isReachTarget = false;
        }

        public void Move_FixTick(float fixdt) {
            if (isReachTarget) {
                return;
            }
            Vector2 curPos = transform.position;
            float moveSpeedDTSqr = moveSpeed * fixdt * moveSpeed;
            if (Vector2.SqrMagnitude(targetPos - curPos) <= moveSpeedDTSqr) {
                rb.MovePosition(targetPos);
                isReachTarget = true;
            } else {
                Vector2 dir = targetPos - curPos;
                Vector2 nextPos = curPos + dir.normalized * moveSpeed * fixdt;
                rb.MovePosition(nextPos);
            }
        }

    }

}