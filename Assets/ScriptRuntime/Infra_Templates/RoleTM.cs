using UnityEngine;

namespace WOW {

    [CreateAssetMenu(fileName = "TM_Role_", menuName = "WOW/RoleTM")]
    public class RoleTM : ScriptableObject {

        public int typeID;
        public string typeName;

        public float hp;
        public float hpMax;

        public float moveSpeed;

    }

}