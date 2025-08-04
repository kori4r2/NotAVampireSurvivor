using NotAVampireSurvivor.Core;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class WeaponController {
        private Weapon weapon;
        private PlayerStats playerStats;

        public WeaponController(Weapon weapon, PlayerStats playerStats) { }

        public void Update(float time, Player player) { }

        public void Destroy() { }

        private float FixedWeaponDamage() {
            return weapon.Stats.Damage;
        }

        private float VariableWeaponDamage() {
            return FixedWeaponDamage() * playerStats.Might.Value;
        }
    }
}