using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Gameplay {
    public class EnemyWaveUpdater {
        private readonly IRuntimeSet<StageEnemy> runtimeSet = null;
        private readonly EnemyPool enemyPool = null;
        private readonly UnityEvent<EnemyWaveUpdater> onClear = new UnityEvent<EnemyWaveUpdater>();
        private bool clear = false;
        public bool Clear => clear;
        private float waveExp;

        public EnemyWaveUpdater(EnemyPool pool, Wave wave, Transform parent) {
            runtimeSet = new EnemyWaveRuntimeSet();
            enemyPool = pool;
            LoadWaveEnemies(wave, parent);
        }

        public void LoadWaveEnemies(Wave wave, Transform parent) {
            clear = false;
            waveExp = CalculateExp(wave);
            foreach (EnemyGroup enemyGroup in wave.EnemyGroups) {
                LoadEnemyGroup(enemyGroup, parent);
            }
        }

        private static float CalculateExp(Wave wave) {
            // TO DO
            return 0;
        }

        private void LoadEnemyGroup(EnemyGroup enemyGroup, Transform parent) {
            // TO DO: Implement different initial positioning
            // TO DO: Allow for delayed spawning instead of doing it all at once
            float randomAngle = Random.value * 360;
            for (int count = 0; count < enemyGroup.Count; count++) {
                StageEnemy newEnemy = enemyPool.InstantiateObject(parent);
                newEnemy.LoadRuntimeSet(runtimeSet);
                newEnemy.LoadEnemyInfo(enemyGroup.Enemy);
                newEnemy.PositionOnMargin(randomAngle + count * (360f / enemyGroup.Count));
            }
        }

        public void SetClearCallback(UnityAction<EnemyWaveUpdater> callback) {
            onClear.AddListener(callback);
        }

        private void ClearWave() {
            clear = true;
            onClear.Invoke(this);
        }

        public void Update(float deltaTime) {
            if (clear) return;

            UpdateEnemies(deltaTime);
        }

        private void UpdateEnemies(float deltaTime) {
            foreach (StageEnemy enemy in runtimeSet.ToArray()) {
                if (!enemy || !enemy.ShouldUpdate) continue;

                enemy.ManagedUpdate(deltaTime);
            }
            if (runtimeSet.Count <= 0) ClearWave();
        }
    }
}