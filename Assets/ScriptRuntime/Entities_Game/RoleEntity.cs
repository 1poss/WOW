using UnityEngine;

namespace WOW {

    public class RoleEntity : MonoBehaviour {

        public readonly EntityType entityType = EntityType.Role;
        public int id;
        public int typeID;

        [SerializeField] Rigidbody2D rb;

        [SerializeField] SpriteRenderer sr;

    }

}