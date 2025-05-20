using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Weapon")]
    public class Weapon : Item {
        [SerializeField] private WeaponStats stats;
        [SerializeField] private WeaponLevel[] levelUps;
        public int UpgradeLevel { get; private set; } = 0;
    }
}
