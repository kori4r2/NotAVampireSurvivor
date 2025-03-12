using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Enemy")]
    public class Enemy : ScriptableObject {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
        [SerializeField] private AnimationInfo animation;
        public AnimationInfo Animation;
        [SerializeField] private EnemyAttack attack;
        public EnemyAttack Attack => attack;
    }
}
