using System.Collections.Generic;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class EnemySet : RuntimeSet<StageEnemy> {
        private readonly List<StageEnemy> enemiesByDistance = new();

        public StageEnemy GetClosestEnemyAlive() {
            if (enemiesByDistance.Count < 1) return null;

            if (enemiesByDistance.Count > 1) enemiesByDistance.Sort(CompareDistances);
            foreach (StageEnemy enemy in enemiesByDistance) {
                if (!enemy.IsDead) return enemy;
            }
            return null;
        }

        public StageEnemy GetRandomLivingEnemy() {
            if (enemiesByDistance.Count < 1) return null;

            int startingIndex = Random.Range(0, enemiesByDistance.Count);
            for (int count = 0; count < enemiesByDistance.Count; count++) {
                int index = (startingIndex + count) % enemiesByDistance.Count;
                if (!enemiesByDistance[index].IsDead) return enemiesByDistance[index];
            }
            return null;
        }

        private static int CompareDistances(StageEnemy a, StageEnemy b) {
            return a.SquareDistance.CompareTo(b);
        }

        public override void AddElement(StageEnemy newElement) {
            if (!Contains(newElement) && !activeObjsDictionary.ContainsKey(newElement.gameObject))
                enemiesByDistance.Add(newElement);
            base.AddElement(newElement);
        }

        public override void RemoveElement(StageEnemy elementToRemove) {
            if (Contains(elementToRemove)) enemiesByDistance.Remove(elementToRemove);
            base.RemoveElement(elementToRemove);
        }

        public override void Clear() {
            base.Clear();
            enemiesByDistance.Clear();
        }
    }
}