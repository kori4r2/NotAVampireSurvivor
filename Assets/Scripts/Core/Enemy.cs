using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Enemy")]
    public class Enemy : ScriptableObject {
        [SerializeField] private Sprite sprite;
        public Sprite Sprite => sprite;
        [SerializeField] private AnimationInfo animation;
        public AnimationInfo Animation => animation;
        [SerializeField] private float moveSpeed;
        public float MoveSpeed => moveSpeed;
        [SerializeField] private float maxHp;
        public float MaxHp => maxHp;

        public Vector2 CalculateSpeed(Vector3 enemyPosition, Transform playerTransform) {
            if (!playerTransform || moveSpeed <= float.Epsilon) return Vector2.zero;

            return (playerTransform.position - enemyPosition).normalized * moveSpeed;
        }
    }
}