using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseDamage : WeaponIntStat {
        public override int ClampValue(float total) {
            return Mathf.Max(0, Mathf.RoundToInt(total));
        }
    }
}