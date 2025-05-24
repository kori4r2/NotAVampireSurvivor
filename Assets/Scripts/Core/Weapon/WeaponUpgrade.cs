using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public struct WeaponUpgrade {
        [SerializeField] private WeaponStatsEnum statIndex;
        [SerializeField] private float increase;

        public readonly void ApplyUpgrade(WeaponStats stats) {
            switch (statIndex) {
                case WeaponStatsEnum.Amount:
                    stats.UpgradeAmount(Mathf.RoundToInt(increase));
                    return;
                case WeaponStatsEnum.Area:
                    stats.UpgradeArea(increase);
                    return;
                case WeaponStatsEnum.Cooldown:
                    stats.UpgradeCooldown(increase);
                    return;
                case WeaponStatsEnum.Damage:
                    stats.UpgradeDamage(Mathf.RoundToInt(increase));
                    return;
                case WeaponStatsEnum.Duration:
                    stats.UpgradeDuration(increase);
                    return;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public readonly string Description => statIndex switch {
            WeaponStatsEnum.Amount => $"Not implemented yet",
            WeaponStatsEnum.Area => $"Not implemented yet",
            WeaponStatsEnum.Cooldown => $"Not implemented yet",
            WeaponStatsEnum.Damage => $"Not implemented yet",
            WeaponStatsEnum.Duration => $"Not implemented yet",
            _ => throw new ArgumentOutOfRangeException(),
        };
    }
}