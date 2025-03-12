using System.Collections.Generic;
using Toblerone.Toolbox;

namespace NotAVampireSurvivor.Gameplay {
    public class EnemyWaveRuntimeSet : InstantiatedRuntimeSet<StageEnemy> {
        public EnemyWaveRuntimeSet() : base() { }
        public EnemyWaveRuntimeSet(List<StageEnemy> enemies) : base() {
            foreach (StageEnemy enemy in enemies)
                AddElement(enemy);
        }
    }
}
