using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseDuration : WeaponFloatStat {
        private const float minDuration = 0.1f;
        protected override float ClampValue(float total) {
            if (value < 0)
                return -1;
            if (value == 0)
                return 0;
            return Mathf.Max(minDuration, total);
        }
    }
}
