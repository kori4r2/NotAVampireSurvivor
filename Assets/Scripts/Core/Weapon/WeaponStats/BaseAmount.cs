using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseAmount : WeaponIntStat {
        public override int ClampValue(float total) {
            return Mathf.Max(1, Mathf.RoundToInt(total));
        }
    }
}