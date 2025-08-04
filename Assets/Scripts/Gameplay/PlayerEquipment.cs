using System.Collections.Generic;
using System.Collections.ObjectModel;
using NotAVampireSurvivor.Core;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class PlayerEquipment : ScriptableObject {
        public const int ItemSlots = 6;
        private readonly List<Weapon> weapons = new();
        private ReadOnlyCollection<Weapon> readOnlyWeapons = null;
        public ReadOnlyCollection<Weapon> EquippedWeapons =>
            readOnlyWeapons ??= new ReadOnlyCollection<Weapon>(weapons);
        private readonly List<Passive> passives = new();
        private ReadOnlyCollection<Passive> readOnlyPassives = null;
        public ReadOnlyCollection<Passive> EquippedPassives =>
            readOnlyPassives ??= new ReadOnlyCollection<Passive>(passives);
        [SerializeField] private PlayerReference player;
        private readonly HashSet<Item> equipped = new();

        public void Reset() {
            foreach (Item item in equipped) {
                item.Reset();
            }
            equipped.Clear();
            weapons.Clear();
            passives.Clear();
        }

        public bool IsEquipped(Item item) {
            return equipped.Contains(item);
        }

        private bool AddNewItem(Item item) {
            if (!equipped.Add(item)) return false;

            item.Reset();
            return true;
        }

        public void Equip(Weapon weapon) {
            if (!AddNewItem(weapon)) return;

            weapons.Add(weapon);
        }

        public void Equip(Passive passive) {
            if (!AddNewItem(passive)) return;

            passives.Add(passive);
        }
    }
}