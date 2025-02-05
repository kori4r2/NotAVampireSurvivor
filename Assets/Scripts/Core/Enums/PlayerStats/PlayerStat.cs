using UnityEngine;

namespace NotAVampireSurvivor.Core {
    public abstract class PlayerStat : ScriptableObject {
        [SerializeField] protected string displayPrefix = "";
        public string DisplayPrefix => displayPrefix;
        [SerializeField] protected string displaySuffix = "";
        public string DisplaySuffix => displaySuffix;
        [SerializeField] protected string valueDescription = "";
        public string ValueDescription => valueDescription;
        [SerializeField] protected Sprite sprite = null;
        public Sprite Sprite => sprite;

        public abstract void RemoveAllObservers();

        public abstract void ApplyBaseStat(float increase);

        public abstract void ResetBaseValue();

        public abstract void ApplyBoost(float increase);

        public abstract void ResetBoost();
    }
}
