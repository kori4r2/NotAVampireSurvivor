using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Enemy")]
    public class Enemy : ScriptableObject {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
        [SerializeField] private RuntimeAnimatorController animatorController;
        public RuntimeAnimatorController AnimatorController => animatorController;
        [SerializeField] private EnemyAttack attack;
        public EnemyAttack Attack => attack;
    }
}
