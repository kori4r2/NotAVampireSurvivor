using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class EnemyPool : ObjectPool<StageEnemy> {
        [SerializeField] private StageEnemy prefab;
        protected override StageEnemy ObjectPrefab => prefab;
        protected override void ExpandPool() { ExpandPoolByCurrentSize(); }
    }
}
