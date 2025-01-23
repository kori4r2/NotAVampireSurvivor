using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/ProjectileCount")]
    public class ProjectileCount : TypedPlayerStat<int> {
        public override int ActiveBoost => Math.Max(0, activeBoost);

        public override int Value => baseValue + ActiveBoost;

        protected override int DefaultValue => 0;

        public override void IncreaseBaseValue(int increase) {
            baseValue += increase;
        }

        public override void IncreaseBoost(int increase) { activeBoost += increase; }
    }
}
