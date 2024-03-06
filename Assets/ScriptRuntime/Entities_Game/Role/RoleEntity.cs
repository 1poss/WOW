using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;
        public string typeName;
        public AllyType allyType;

        [SerializeField] public Transform body;
        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;
        [SerializeField] SpriteRenderer chosenSR;
        [SerializeField] LineRenderer lr;

        public RoleMod mod;

        public Sprite portraitIcon;

        public bool isClickMoving;
        public Vector2 targetPos;

        public RoleFSMComponent fsm;
        public RoleAIComponent aiComponent;
        public RoleSkillSlotComponent skillSlotComponent;
        public RoleAttrComponent attrComponent;
        public RoleCommandComponent commandComponent;

        [SerializeField] UI.HUD_HpBar hpBar;

        public void Ctor() {

            isClickMoving = false;
            chosenSR.enabled = false;

            fsm = new RoleFSMComponent();
            aiComponent = new RoleAIComponent();
            skillSlotComponent = new RoleSkillSlotComponent();
            attrComponent = new RoleAttrComponent();
            commandComponent = new RoleCommandComponent();

        }

        public Vector2Int Pos_PosInt() {
            return new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

        public Vector2 Pos_Pos() {
            return transform.position;
        }

        public void Pos_Set(Vector2 pos) {
            transform.position = pos;
        }

        public void Move_Start(Vector2 targetPos) {
            this.targetPos = targetPos;
            this.isClickMoving = true;
            lr.enabled = true;
            lr.positionCount = 2;
            lr.SetPosition(1, targetPos);
        }

        public bool Move_To(Vector2 targetPos, float reachRange) {
            Vector2 dir = targetPos - (Vector2)transform.position;
            if (dir.sqrMagnitude > reachRange * reachRange) {
                Face_Dir(dir);
                rb.velocity = dir.normalized * attrComponent.moveSpeed;
                return false;
            } else {
                rb.velocity = Vector2.zero;
                return true;
            }
        }

        public void Move_ByClickTick(float fixdt) {

            if (!isClickMoving) {
                lr.enabled = false;
                mod.Param_SetMagnitude(0);
                return;
            }

            Vector2 curPos = transform.position;
            float moveSpeed = attrComponent.moveSpeed;
            float moveSpeedDTSqr = moveSpeed * fixdt * moveSpeed * fixdt;
            Vector2 dir = targetPos - curPos;
            if (dir.sqrMagnitude <= moveSpeedDTSqr) {
                rb.MovePosition(targetPos);
                isClickMoving = false;
            } else {
                Vector2 nextPos = curPos + dir.normalized * moveSpeed * fixdt;
                rb.MovePosition(nextPos);
            }

            lr.SetPosition(0, transform.position);

            mod.Param_SetMagnitude(1);

            Face_Dir(dir);

        }

        public void Move_Stop() {
            isClickMoving = false;
            lr.enabled = false;
            mod.Param_SetMagnitude(0);
        }

        public Vector2 Move_GetVelocity() {
            return rb.velocity;
        }

        public void Face_Dir(Vector2 dir) {
            if (dir.x > 0) {
                body.localScale = new Vector3(-1, 1, 1);
            } else if (dir.x < 0) {
                body.localScale = new Vector3(1, 1, 1);
            }
        }

        public void SR_Chosen(bool chosen) {
            chosenSR.enabled = chosen;
            lr.enabled = chosen;
        }

        public void HUD_HpBarUpdate() {
            hpBar.SetHp(attrComponent.hp, attrComponent.hpMax);
        }

    }

}