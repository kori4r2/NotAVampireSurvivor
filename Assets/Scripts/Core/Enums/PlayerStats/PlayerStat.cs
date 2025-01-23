using UnityEngine;

namespace NotAVampireSurvivor.Core {
    public abstract class PlayerStat : ScriptableObject {
        [SerializeField] protected Sprite sprite;
        public Sprite Sprite => sprite;

        public abstract void RemoveAllObservers();

        public abstract void ResetBaseValue();

        public abstract void ResetBoost();
    }
}
