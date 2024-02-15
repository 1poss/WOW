using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;
        public AllyType allyType;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;
        [SerializeField] LineRenderer lr;

        public bool isReachTarget;
        public Vector2 targetPos;
        public float moveSpeed;

        public void Ctor() {
            moveSpeed = 5;
            isReachTarget = true;
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
                return;
            }

            lr.enabled = true;

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

            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, targetPos);
            
        }

    }

}