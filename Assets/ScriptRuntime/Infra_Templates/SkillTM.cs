using UnityEngine;

namespace WOW {

    [CreateAssetMenu(fileName = "TM_Skill_", menuName = "WOW/SkillTM")]
    public class SkillTM : ScriptableObject {

        public int typeID;
        public string typeName;

        public SkillType skillType;
        public SkillCastDirection castDirection;
        public SkillIndicateType indicateType;

        public float cdSec;

        public float castRange;

        public float preSec;
        public float actSec;
        public float actInterval;
        public float postSec;

        public bool hasSpawnBullet;
        public SkillSpawnPositionType spawnPositionType;
        public BulletTM spawnBullet;

        public bool hasActEffector;
        public EffectorModel actEffector;

        public bool hasActCollider;
        public ShapeType actColliderShape;
        public Vector2 actColliderOffset;
        public Vector2 actColliderSize;

        public bool hasHitEffector;
        public EffectorModel hitEffector;

    }
}