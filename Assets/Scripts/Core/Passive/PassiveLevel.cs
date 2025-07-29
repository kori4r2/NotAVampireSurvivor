using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public class PassiveLevel {
        [SerializeField, TextArea(2, 2)] private string description;
        public string Description => description;
        public StatBoost[] boosts;
    }
}