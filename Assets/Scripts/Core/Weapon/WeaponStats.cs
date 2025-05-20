using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public class WeaponStats {
        [SerializeField/*, Range(1, 200)*/] private BaseDamage baseDamage;
        public int Damage => baseDamage.Value;
        [SerializeField/*, Range(0.1f, 30f)*/] private BaseCooldown cooldown;
        public float Cooldown => cooldown.Value;
        [SerializeField/*, Range(0f, 30f)*/] private BaseDuration duration;
        public float Duration => duration.Value;
        [SerializeField/*, Range(0f, 30f)*/] private BaseArea area;
        public float Area => area.Value;
        [SerializeField/*, Range(0, 10)*/] private BaseAmount projectileCount;
        public int ProjectileCount => projectileCount.Value;
        private UnityEvent<WeaponStats> onChange = new UnityEvent<WeaponStats>();

        public void ResetStats() {
            baseDamage.ResetValue();
            cooldown.ResetValue();
            area.ResetValue();
            duration.ResetValue();
            projectileCount.ResetValue();
            onChange.Invoke(this);
        }

        public void UpgradeDamage(int increase) {
            baseDamage.AddBoost(increase);
            onChange.Invoke(this);
        }

        public void UpgradeCooldown(float increase) {
            cooldown.AddBoost(increase);
            onChange.Invoke(this);
        }

        public void UpgradeArea(float increase) {
            area.AddBoost(increase);
            onChange.Invoke(this);
        }

        public void UpgradeDuration(float increase) {
            duration.AddBoost(increase);
            onChange.Invoke(this);
        }

        public void UpgradeAmount(int increase) {
            projectileCount.AddBoost(increase);
            onChange.Invoke(this);
        }

        public void ObserveChanges(UnityAction<WeaponStats> callback) {
            onChange.AddListener(callback);
        }

        public void StopObserving(UnityAction<WeaponStats> callback) {
            onChange.RemoveListener(callback);
        }

        public void RemoveAllObservers() {
            onChange.RemoveAllListeners();
        }
    }
}
