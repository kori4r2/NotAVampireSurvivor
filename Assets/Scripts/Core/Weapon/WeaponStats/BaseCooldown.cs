using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseCooldown : WeaponFloatStat {
        private const float minCooldown = 0.1f;
        protected override float ClampValue(float total) {
            return Mathf.Max(minCooldown, total);
        }
    }
}
