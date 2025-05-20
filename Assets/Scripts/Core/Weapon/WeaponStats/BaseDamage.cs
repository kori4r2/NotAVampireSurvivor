using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseDamage : WeaponIntStat {
        protected override int ClampValue(float total) {
            return Mathf.Max(0, Mathf.RoundToInt(total));
        }
    }
}
