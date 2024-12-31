using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class StatList {
        [SerializeField, Range(1.0f, 10.0f)] private float might;
        public float BaseMight => might = 1.0f;
        public float MightBoost => ActiveBoosts.ContainsKey(Stat.Might) ? ActiveBoosts[Stat.Might] : 0;
        public float Might => might * (1.0f + MightBoost);
        [SerializeField, Range(1.0f, 10f)] private float cooldownSpeed = 1.0f;
        public float BaseCooldownSpeed => cooldownSpeed;
        public float CooldownSpeedBoost => ActiveBoosts.ContainsKey(Stat.CooldownSpeed) ? ActiveBoosts[Stat.CooldownSpeed] : 0;
        public float CooldownSpeed => cooldownSpeed * (1.0f + CooldownSpeedBoost);
        [SerializeField, Range(1.0f, 10f)] private float area = 1.0f;
        public float BaseArea => area;
        public float AreaBoost => ActiveBoosts.ContainsKey(Stat.Area) ? ActiveBoosts[Stat.Area] : 0;
        public float Area => area * (1.0f + AreaBoost);
        [SerializeField, Range(1.0f, 5.0f)] private float speed = 1.0f;
        public float BaseSpeed => speed;
        public float SpeedBoost => ActiveBoosts.ContainsKey(Stat.Speed) ? ActiveBoosts[Stat.Speed] : 0;
        public float Speed => speed * (1.0f + SpeedBoost);
        [SerializeField, Range(1.0f, 10f)] private float projectileSpeed = 1.0f;
        public float BaseProjectileSpeed => projectileSpeed;
        public float ProjectileSpeedBoost => ActiveBoosts.ContainsKey(Stat.ProjectileSpeed) ? ActiveBoosts[Stat.ProjectileSpeed] : 0;
        public float ProjectileSpeed => projectileSpeed * (1.0f + ProjectileSpeedBoost);
        [SerializeField, Range(0, 10)] private int projectileCount = 0;
        public int BaseProjectileCount => projectileCount;
        public int ProjectileCountBoost => Math.Max(0, Mathf.FloorToInt(ActiveBoosts.ContainsKey(Stat.ProjectileCount) ? ActiveBoosts[Stat.ProjectileCount] : 0));
        public int ProjectileCount => projectileCount + ProjectileCountBoost;
        [SerializeField, Range(1.0f, 10f)] private float duration = 1.0f;
        public float BaseDuration => duration;
        public float DurationBoost => ActiveBoosts.ContainsKey(Stat.Duration) ? ActiveBoosts[Stat.Duration] : 0;
        public float Duration => duration * (1.0f + DurationBoost);
        [SerializeField, Range(0, 50)] private float armor = 0;
        public float BaseArmor => armor;
        public float ArmorBoost => ActiveBoosts.ContainsKey(Stat.Armor) ? ActiveBoosts[Stat.Armor] : 0;
        public float Armor => armor * (1.0f + ArmorBoost);
        [SerializeField, Range(1.0f, 500f)] private float health = 100;
        public float BaseHealth => health;
        public float HealthBoost => ActiveBoosts.ContainsKey(Stat.Health) ? ActiveBoosts[Stat.Health] : 0;
        public float Health => health * (1.0f + HealthBoost);
        [SerializeField, Range(0, 50f)] private float healthRegen = 0;
        public float BaseHealthRegen => healthRegen;
        public float HealthRegenBoost => ActiveBoosts.ContainsKey(Stat.HealthRegen) ? ActiveBoosts[Stat.HealthRegen] : 0;
        public float HealthRegen => healthRegen * (1.0f + HealthRegenBoost);
        private Dictionary<Stat, float> ActiveBoosts = new Dictionary<Stat, float>();
        private Dictionary<Stat, UnityEvent<Stat>> onStatChange = new Dictionary<Stat, UnityEvent<Stat>>();
        private UnityEvent<StatList> onChange = new UnityEvent<StatList>();

        public StatList() {
            foreach (Stat stat in Enum.GetValues(typeof(Stat))) {
                onStatChange[stat] = new UnityEvent<Stat>();
            }
        }

        public StatList(StatList other) {
            CopyBaseStats(other);
            foreach (Stat stat in Enum.GetValues(typeof(Stat))) {
                onStatChange[stat] = new UnityEvent<Stat>();
                if (!other.ActiveBoosts.ContainsKey(stat))
                    continue;
                ActiveBoosts[stat] = other.ActiveBoosts[stat];
            }
        }

        public void CopyBaseStats(StatList other) {
            might = other.might;
            cooldownSpeed = other.cooldownSpeed;
            area = other.area;
            speed = other.speed;
            projectileSpeed = other.projectileSpeed;
            projectileCount = other.projectileCount;
            duration = other.duration;
            armor = other.armor;
            health = other.health;
            healthRegen = other.healthRegen;
        }

        public void CopyActiveBoosts(StatList other) {
            ActiveBoosts.Clear();
            foreach (Stat stat in Enum.GetValues(typeof(Stat))) {
                if (!other.ActiveBoosts.ContainsKey(stat))
                    continue;
                ActiveBoosts[stat] = other.ActiveBoosts[stat];
            }
        }

        public void ObserveChanges(UnityAction<StatList> callback) {
            onChange.AddListener(callback);
        }

        public void ObserveChanges(Stat stat, UnityAction<Stat> callback) {
            onStatChange[stat]?.AddListener(callback);
        }

        public void RemoveAllObservers() {
            onChange.RemoveAllListeners();
            foreach (Stat stat in Enum.GetValues(typeof(Stat))) {
                onStatChange[stat]?.RemoveAllListeners();
            }
        }

        public void ResetBoosts() {
            ActiveBoosts.Clear();
            onChange.Invoke(this);
            foreach (Stat stat in Enum.GetValues(typeof(Stat))) {
                onStatChange[stat]?.Invoke(stat);
            }
        }

        public void AddBoost(StatBoost boost) {
            if (ActiveBoosts.ContainsKey(boost.stat))
                ActiveBoosts[boost.stat] += boost.increase;
            else
                ActiveBoosts[boost.stat] = boost.increase;
            onChange.Invoke(this);
            onStatChange[boost.stat]?.Invoke(boost.stat);
        }
    }
}
