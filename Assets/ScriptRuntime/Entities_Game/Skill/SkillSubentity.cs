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

        public SkillStage stage;

        public float preSec;
        public float preTimer;

        public float actSec;
        public float actTimer;
        public float actInterval;
        public float actIntervalTimer;

        public float postSec;
        public float postTimer;

        public bool hasSpawnBullet;
        public SkillSpawnPositionType spawnPositionType;

        public bool hasActCollider;
        public ShapeType actColliderShape;
        public Vector2 actColliderSize;

    }

}