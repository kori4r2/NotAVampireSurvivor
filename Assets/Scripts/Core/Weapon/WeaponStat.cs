using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public abstract class WeaponStat {
        [SerializeField] protected float value;
        protected float CurrentBoost { get; set; }
        public void ResetValue() { CurrentBoost = 0; }
    }
}
