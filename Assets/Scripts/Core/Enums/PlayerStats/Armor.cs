using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/Armor")]
    public class Armor : TypedPlayerStat<int> {
        public override int ActiveBoost => activeBoost;

        public override int Value => Math.Max(0, baseValue + ActiveBoost);

        protected override int DefaultValue => 0;

        protected override void IncreaseBaseValue(int increase) {
            baseValue += increase;
        }

        protected override void IncreaseBoost(int increase) { activeBoost += increase; }
    }
}
