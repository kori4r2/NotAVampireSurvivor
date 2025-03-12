using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class StageEnemy : PoolableManagedBehaviour {
        [SerializeField] protected RuntimeSet<StageEnemy> enemiesSet;
        protected IRuntimeSet<StageEnemy> enemyWaveSet = null;
        public bool IsDead { get; private set; } = false;

        public override void ManagedUpdate(float deltaTime) {
        }

        public override void ResetObject() {
        }

        public virtual void LoadRuntimeSet(IRuntimeSet<StageEnemy> runtimeSet) {
            enemyWaveSet = runtimeSet;
            if (isActiveAndEnabled && !runtimeSet.Contains(this))
                runtimeSet.AddElement(this);
        }

        public void LoadEnemyInfo(Enemy enemyInfo) { }

        protected override void AddToRuntimeSet() {
            enemiesSet.AddElement(this);
            if (enemyWaveSet != null)
                enemyWaveSet.AddElement(this);
        }

        protected override void RemoveFromRuntimeSet() {
            enemiesSet.RemoveElement(this);
            if (enemyWaveSet != null)
                enemyWaveSet.RemoveElement(this);
        }
    }
}
