using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public class WeaponStats {
        [SerializeField, Range(1, 200)] private int baseDamage;
        public int Damage { get; private set; }
        [SerializeField, Range(0.1f, 30f)] private float cooldown;
        public float Cooldown { get; private set; }
        [SerializeField, Range(0f, 30f)] private float duration;
        public float Duration { get; private set; }
        [SerializeField, Range(0, 10)] private int projectileCount;
        public int ProjectileCount { get; private set; }
        [SerializeField, Range(0f, 50f)] private float projectileSpeed;
        public float ProjectileSpeed { get; private set; }
        private UnityEvent<WeaponStats> onChange = new UnityEvent<WeaponStats>();

        public void ResetStats() {
            Damage = baseDamage;
            Cooldown = cooldown;
            Duration = duration;
            ProjectileCount = projectileCount;
            ProjectileSpeed = projectileSpeed;
            onChange.Invoke(this);
        }

        public void ApplyUpgrade(WeaponUpgrade upgrade) {
            // switch (upgrade.stat) {
            //     case WeaponStat.Damage:
            //         Damage += Mathf.FloorToInt(upgrade.increase);
            //         break;
            //     case WeaponStat.Cooldown:
            //         Cooldown += upgrade.increase;
            //         break;
            //     case WeaponStat.Duration:
            //         Duration += upgrade.increase;
            //         break;
            //     case WeaponStat.ProjectileCount:
            //         ProjectileCount += Mathf.FloorToInt(upgrade.increase);
            //         break;
            //     case WeaponStat.ProjectileSpeed:
            //         ProjectileSpeed += upgrade.increase;
            //         break;
            //     default:
            //         Debug.LogError($"[WeaponStats]: Invalid WeaponStat value: {upgrade.stat}");
            //         return;
            // }
            onChange.Invoke(this);
        }

        public void ObserveChanges(UnityAction<WeaponStats> callback) {
            onChange.AddListener(callback);
        }

        public void RemoveAllObservers() {
            onChange.RemoveAllListeners();
        }
    }
}
