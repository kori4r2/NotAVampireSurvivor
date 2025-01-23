using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/MaxHealth")]
    public class MaxHealth : TypedPlayerStat<int> {
        public override int ActiveBoost => activeBoost;

        public override int Value => Math.Max(1, baseValue + ActiveBoost);

        protected override int DefaultValue => 100;

        public override void IncreaseBaseValue(int increase) {
            baseValue += increase;
        }

        public override void IncreaseBoost(int increase) { activeBoost += increase; }
    }
}
