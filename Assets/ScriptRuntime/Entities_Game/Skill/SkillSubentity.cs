using UnityEngine;

namespace WOW {

    public class SkillSubentity {

        public int id;
        public int typeID;
        public string typeName;

        public SkillCastDirection castDirection;
        public SkillIndicateType indicateType;

        public float cdSec;
        public float cdTimer;

        public float preSec;

        public float actSec;
        public float actInterval;

        public float postSec;

        public bool hasSpawnBullet;
        public SkillSpawnPositionType spawnPositionType;

        public bool hasActCollider;
        public ShapeType actColliderShape;
        public Vector2 actColliderSize;

    }

}