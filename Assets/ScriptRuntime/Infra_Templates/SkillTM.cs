using UnityEngine;

namespace WOW {

    [CreateAssetMenu(fileName = "TM_Skill_", menuName = "WOW/SkillTM")]
    public class SkillTM : ScriptableObject {

        public int typeID;
        public string typeName;

        public SkillCastDirection castDirection;
        public SkillIndicateType indicateType;

        public float cdSec;

        public float preSec;
        public float actSec;
        public float actInterval;
        public float postSec;

        public bool hasSpawnBullet;
        public SkillSpawnPositionType spawnPositionType;
        public BulletTM spawnBullet;

    }
}