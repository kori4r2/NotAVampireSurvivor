using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public class Wave {
        [SerializeField] private EnemyGroup[] enemyGroups;
        public EnemyGroup[] EnemyGroups => enemyGroups;
        [SerializeField] private float spawnTime;
        public float SpawnTime => spawnTime;
    }
}
