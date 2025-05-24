using System;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public abstract class WeaponIntStat : WeaponStat {
        public abstract int ClampValue(float total);
        public int Value => ClampValue(value + CurrentBoost);

        public void AddBoost(int boost) {
            CurrentBoost += boost;
        }
    }
}