using UnityEngine;

namespace WOW {

    public class SkillSubentity {

        public int id;
        public int typeID;
        public string typeName;

        public SkillType skillType;
        public SkillCastDirection castDirection;
        public SkillIndicateType indicateType;

        public float cdSec;
        public float cdTimer;

        public float castRange; // 1. 目标在攻击范围内

        public float preSec;

        public float actSec;
        public float actInterval;

        public float postSec;

        public bool hasSpawnBullet;
        public SkillSpawnPositionType spawnPositionType;

        // ==== Act ====
        public bool hasActEffector;
        public EffectorModel actEffector;

        public bool hasActCollider;
        public Vector2 actColliderOffset; // 2. 包围盒的中心点
        public ShapeType actColliderShape; // 3. 包围盒的形状, 当ShapeType为Point时, 指向一个目标
        public Vector2 actColliderSize; // 4. 包围盒的大小

        public bool hasHitEffector;
        public EffectorModel hitEffector; // 6. 命中效果器

    }

}