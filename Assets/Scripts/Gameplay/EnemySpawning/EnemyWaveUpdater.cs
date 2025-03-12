using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Gameplay {
    public class EnemyWaveUpdater {
        private IRuntimeSet<StageEnemy> runtimeSet = null;
        private EnemyPool enemyPool = null;
        private UnityEvent<EnemyWaveUpdater> onClear = new UnityEvent<EnemyWaveUpdater>();
        private bool clear = false;

        public EnemyWaveUpdater(EnemyPool pool, Wave wave, Transform parent) {
            runtimeSet = new EnemyWaveRuntimeSet();
            enemyPool = pool;
            LoadWaveEnemies(wave, parent);
        }

        public void LoadWaveEnemies(Wave wave, Transform parent) {
            clear = false;
            foreach (EnemyGroup enemyGroup in wave.EnemyGroups) {
                LoadEnemyGroup(enemyGroup, parent);
            }
        }

        private void LoadEnemyGroup(EnemyGroup enemyGroup, Transform parent) {
            for (int count = 0; count < enemyGroup.Count; count++) {
                StageEnemy newEnemy = enemyPool.InstantiateObject(parent);
                newEnemy.LoadRuntimeSet(runtimeSet);
                newEnemy.LoadEnemyInfo(enemyGroup.Enemy);
            }
        }

        public void SetClearCallback(UnityAction<EnemyWaveUpdater> callback) {
            onClear.AddListener(callback);
        }

        private void ClearWave() {
            onClear.Invoke(this);
            clear = true;
        }

        public void Update(float deltaTime) {
            if (clear)
                return;
            UpdateEnemies(deltaTime);
        }

        private void UpdateEnemies(float deltaTime) {
            foreach (StageEnemy enemy in runtimeSet.ToArray()) {
                if (!enemy || !enemy.ShouldUpdate)
                    continue;
                enemy.ManagedUpdate(deltaTime);
            }
            if (runtimeSet.Count <= 0)
                ClearWave();
        }
    }
}
