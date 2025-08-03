using System;
using System.Collections.Generic;
using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class StageEnemySpawner : MonoBehaviour {
        [SerializeField] private EnemyPool enemyPool;
        [SerializeField] private RuntimeSet<StageEnemy> enemiesSet;
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private FloatVariable gameTime;
        [SerializeField] private BoolVariable isPaused;
        private List<EnemyWaveUpdater> updaters = new List<EnemyWaveUpdater>();
        private List<EnemyWaveUpdater> deletedUpdaters = new List<EnemyWaveUpdater>();
        private Queue<EnemyWaveUpdater> recyclingUpdaters = new Queue<EnemyWaveUpdater>();
        private Queue<Wave> pendingWaves = new Queue<Wave>();
        private VariableObserver<float> timerObserver;

        private void Start() {
            Array.Sort(runSettings.Stage.Waves, (a, b) => a.SpawnTime.CompareTo(b.SpawnTime));
            foreach (Wave wave in runSettings.Stage.Waves) {
                pendingWaves.Enqueue(wave);
            }
            SpawnTimeWaves(gameTime.Value);
            timerObserver = new VariableObserver<float>(gameTime, SpawnTimeWaves);
            timerObserver.StartWatching();
        }

        private void SpawnTimeWaves(float time) {
            if (time < pendingWaves.Peek().SpawnTime) return;

            while (pendingWaves.Peek().SpawnTime >= time) {
                SpawnWave(pendingWaves.Dequeue());
            }
        }

        private void SpawnWave(Wave wave) {
            EnemyWaveUpdater updater = NewOrRecycledUpdater(wave);
            updaters.Add(updater);
        }

        private EnemyWaveUpdater NewOrRecycledUpdater(Wave wave) {
            if (recyclingUpdaters.Count < 1) {
                EnemyWaveUpdater newUpdater = new EnemyWaveUpdater(enemyPool, wave, transform);
                newUpdater.SetClearCallback(destroyed => deletedUpdaters.Add(destroyed));
                return newUpdater;
            }
            EnemyWaveUpdater recycled = recyclingUpdaters.Dequeue();
            recycled.LoadWaveEnemies(wave, transform);
            return recycled;
        }

        private void Update() {
            if (isPaused.Value || updaters.Count < 1) return;

            foreach (EnemyWaveUpdater updater in updaters) {
                updater.Update(Time.deltaTime);
            }
            foreach (EnemyWaveUpdater updater in deletedUpdaters) {
                updaters.Remove(updater);
                recyclingUpdaters.Enqueue(updater);
            }
            deletedUpdaters.Clear();
        }

        private void OnDestroy() {
            timerObserver.StopWatching();
        }
    }
}