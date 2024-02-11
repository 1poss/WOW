using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

        public Vector2Int[] path;

        public void Ctor() {
            path = new Vector2Int[10000];
        }

        public Vector2Int Pos_PosInt() {
            return new Vector2Int((int)transform.position.x, (int)transform.position.y);
        }

    }

}