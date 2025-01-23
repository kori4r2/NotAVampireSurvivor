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

        public abstract void IncreaseBaseValue(T increase);

        public void AddBaseValue(T increase) {
            IncreaseBaseValue(increase);
            onStatChange.Invoke(Value);
        }

        public override void ResetBaseValue() {
            baseValue = DefaultValue;
        }

        public override void ResetBoost() {
            activeBoost = default;
            onStatChange.Invoke(Value);
        }

        public abstract void IncreaseBoost(T increase);

        public void AddBoost(T increase) {
            IncreaseBoost(increase);
            onStatChange.Invoke(Value);
        }
    }
}
