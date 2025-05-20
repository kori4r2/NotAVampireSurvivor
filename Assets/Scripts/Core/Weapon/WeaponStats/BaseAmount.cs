using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseAmount : WeaponIntStat {
        protected override int ClampValue(float total) {
            return Mathf.Max(1, Mathf.RoundToInt(total));
        }
    }
}
