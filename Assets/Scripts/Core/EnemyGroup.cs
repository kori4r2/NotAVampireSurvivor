using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Enemy Group")]
    public class EnemyGroup : ScriptableObject {
        [SerializeField] private Enemy enemy;
        public Enemy Enemy => enemy;
        [SerializeField] private int count;
        public int Count => count;
    }
}
