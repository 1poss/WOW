using UnityEngine;

namespace WOW {

    [CreateAssetMenu(fileName = "TM_Bullet_", menuName = "WOW/BulletTM")]
    public class BulletTM : ScriptableObject {

        public int typeID;
        public string typeName;

        public float moveSpeed;

    }

}