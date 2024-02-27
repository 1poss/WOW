using System;
using UnityEngine;

namespace WOW {

    [Serializable]
    public struct EffectorModel {

        public bool hasInstantDamage;
        public float instantDamage;

        public bool hasInstantHeal;
        public float instantHeal;

        public bool hasBuff;

        public bool hasExplosion;
        public float explosionRadius;
        public float explosionDamage;

        public bool hasLink;
        public int linkCount;
        public float linkDamage;

    }

}