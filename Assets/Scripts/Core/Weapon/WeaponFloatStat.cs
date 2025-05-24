using System;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public abstract class WeaponFloatStat : WeaponStat {
        public abstract float ClampValue(float total);
        public float Value => ClampValue(value + CurrentBoost);

        public void AddBoost(float boost) {
            CurrentBoost += boost;
        }
    }
}