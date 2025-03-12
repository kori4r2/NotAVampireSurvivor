using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [System.Serializable]
    public class Wave {
        [SerializeField] private EnemyGroup[] enemyGroups;
        public EnemyGroup[] EnemyGroups => enemyGroups;
        [SerializeField, TimeFloat] private float spawnTime;
        public float SpawnTime => spawnTime;
    }
}
