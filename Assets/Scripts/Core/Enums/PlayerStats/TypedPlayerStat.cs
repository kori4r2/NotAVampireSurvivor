using System;
using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Core {
    public abstract class TypedPlayerStat<T> : PlayerStat {
        protected abstract T DefaultValue { get; }
        [SerializeField] protected T baseValue;
        public T BaseValue => baseValue;
        protected T activeBoost;
        public abstract T ActiveBoost { get; }
        public abstract T Value { get; }

        protected UnityEvent<T> onStatChange = new UnityEvent<T>();

        public void ObserveChanges(UnityAction<T> callback) {
            onStatChange.AddListener(callback);
        }

        public void RemoveListener(UnityAction<T> callback) {
            onStatChange.RemoveListener(callback);
        }

        public override void RemoveAllObservers() {
            onStatChange.RemoveAllListeners();
        }

        protected abstract void IncreaseBaseValue(T increase);

        public override void ApplyBaseStat(float increase) {
            T value = (T)Convert.ChangeType(increase, typeof(T));
            IncreaseBaseValue(value);
            onStatChange.Invoke(Value);
        }

        public override void ResetBaseValue() {
            baseValue = DefaultValue;
        }

        protected abstract void IncreaseBoost(T increase);

        public override void ApplyBoost(float increase) {
            T value = (T)Convert.ChangeType(increase, typeof(T));
            IncreaseBoost(value);
            onStatChange.Invoke(Value);
        }

        public override void ResetBoost() {
            activeBoost = default;
            onStatChange.Invoke(Value);
        }
    }
}
