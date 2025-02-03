using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/Speed")]
    public class Speed : TypedPlayerStat<float> {
        public override float ActiveBoost => activeBoost;

        public override float Value => baseValue + ActiveBoost;

        protected override float DefaultValue => 1.0f;

        protected override void IncreaseBaseValue(float increase) {
            baseValue += increase;
        }

        protected override void IncreaseBoost(float increase) { activeBoost += increase; }
    }
}
