using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/ProjectileSpeed")]
    public class ProjectileSpeed : TypedPlayerStat<float> {
        public override float ActiveBoost => activeBoost;

        public override float Value => baseValue + ActiveBoost;

        protected override float DefaultValue => 1.0f;

        protected override void IncreaseBaseValue(float increase) {
            baseValue += increase;
        }

        protected override void IncreaseBoost(float increase) { activeBoost += increase; }
    }
}
