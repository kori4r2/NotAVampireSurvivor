using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/HealthRegen")]
    public class HealthRegen : TypedPlayerStat<float> {
        public override float ActiveBoost => activeBoost;

        public override float Value => baseValue + ActiveBoost;

        protected override float DefaultValue => 0f;

        public override void IncreaseBaseValue(float increase) {
            baseValue += increase;
        }

        public override void IncreaseBoost(float increase) { activeBoost += increase; }
    }
}
