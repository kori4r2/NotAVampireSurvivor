using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseDuration : WeaponFloatStat {
        private const float minDuration = 0.1f;

        public override float ClampValue(float total) {
            return total switch {
                < 0 => -1,
                0 => 0,
                _ => Mathf.Max(minDuration, total)
            };
        }
    }
}