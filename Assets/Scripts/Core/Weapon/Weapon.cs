using System.Collections.Generic;
using System.Collections.ObjectModel;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Weapon")]
    public class Weapon : Item {
        [SerializeField] private WeaponStats stats;
        public WeaponStats Stats => stats;
        [SerializeField] private WeaponLevel[] levelUps;
        [SerializeField] private PlayerStat[] relevantStats;
        private ReadOnlyCollection<PlayerStat> readonlyRelevanStats = null;
        public ReadOnlyCollection<PlayerStat> RelevantStats =>
            readonlyRelevanStats ??= new ReadOnlyCollection<PlayerStat>(relevantStats);
        public int UpgradeLevel { get; private set; } = 0;
    }
}