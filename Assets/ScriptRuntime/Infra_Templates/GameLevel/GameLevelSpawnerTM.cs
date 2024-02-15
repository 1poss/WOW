using System;
using UnityEngine;

namespace WOW {

    [Serializable]
    public struct GameLevelSpawnerTM {

        public AllyType allyType;
        public EntityType entityType;
        public int typeID;
        public Vector2 spawnPos;

    }

}