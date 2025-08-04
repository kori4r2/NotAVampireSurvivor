using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class StageEnemy : PoolableManagedBehaviour {
        [SerializeField] private PlayerReference playerReference;
        [SerializeField] protected EnemySet enemiesSet;
        protected IRuntimeSet<StageEnemy> enemyWaveSet = null;
        public bool IsDead { get; private set; } = false;
        public float SquareDistance { get; private set; } = float.MaxValue;

        public override void ManagedUpdate(float deltaTime) {
            UpdateDistance();
        }

        private void UpdateDistance() {
            SquareDistance = IsDead || !playerReference.Value ?
                float.MaxValue :
                (playerReference.Value.transform.position - transform.position).sqrMagnitude;
        }

        public override void ResetObject() { }

        public virtual void LoadRuntimeSet(IRuntimeSet<StageEnemy> runtimeSet) {
            enemyWaveSet = runtimeSet;
            if (isActiveAndEnabled && !runtimeSet.Contains(this)) runtimeSet.AddElement(this);
        }

        public void LoadEnemyInfo(Enemy enemyInfo) { }

        protected override void AddToRuntimeSet() {
            enemiesSet.AddElement(this);
            if (enemyWaveSet != null) enemyWaveSet.AddElement(this);
        }

        protected override void RemoveFromRuntimeSet() {
            enemiesSet.RemoveElement(this);
            if (enemyWaveSet != null) enemyWaveSet.RemoveElement(this);
        }
    }
}