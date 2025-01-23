using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Character")]
    public class Character : ScriptableObject {
        [SerializeField] private string characterName;
        public string Name => characterName;
        [SerializeField] private Weapon defaultWeapon;
        public Weapon DefaultWeapon => defaultWeapon;
        [SerializeField] private RuntimeAnimatorController animatorController;
        public RuntimeAnimatorController AnimatorController => animatorController;
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
    }
}
