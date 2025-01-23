using System.Collections.Generic;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/PlayerStat/PlayerStats")]
    public class PlayerStats : ScriptableObject {
        [SerializeField] private Area area;
        public Area Area => area;
        [SerializeField] private Armor armor;
        public Armor Armor => armor;
        [SerializeField] private CooldownSpeed cooldownSpeed;
        public CooldownSpeed CooldownSpeed => cooldownSpeed;
        [SerializeField] private Duration duration;
        public Duration Duration => duration;
        [SerializeField] private HealthRegen healthRegen;
        public HealthRegen HealthRegen => healthRegen;
        [SerializeField] private MaxHealth maxHealth;
        public MaxHealth MaxHealth => maxHealth;
        [SerializeField] private Might might;
        public Might Might => might;
        [SerializeField] private ProjectileCount projectileCount;
        public ProjectileCount ProjectileCount => projectileCount;
        [SerializeField] private ProjectileSpeed projectileSpeed;
        public ProjectileSpeed ProjectileSpeed => projectileSpeed;
        [SerializeField] private Speed speed;
        public Speed Speed => speed;

        private List<PlayerStat> stats = new List<PlayerStat>();

        private void OnEnable() {
            stats = new List<PlayerStat>{
                armor,
                maxHealth,
                projectileCount,
                area,
                cooldownSpeed,
                duration,
                healthRegen,
                might,
                projectileSpeed,
                speed
            };
        }

        public void ResetAllBoosts() {
            foreach (PlayerStat stat in stats) {
                stat.ResetBoost();
            }
        }

        public void ResetAllBaseStats() {
            foreach (PlayerStat stat in stats) {
                stat.ResetBaseValue();
            }
        }

        private void Reset() {
            OnEnable();
        }
    }
}
