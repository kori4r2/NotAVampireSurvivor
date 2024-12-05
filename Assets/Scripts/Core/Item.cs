using UnityEngine;

namespace NotAVampireSurvivor.Core {
    public class Item : ScriptableObject {
        [SerializeField] protected string itemName;
        public string Name => itemName;
        [SerializeField] protected string description;
        public string Description => description;
        [SerializeField] protected Sprite sprite;
        public Sprite Sprite => sprite;
        public int Level { get; set; } = 0;
    }
}
