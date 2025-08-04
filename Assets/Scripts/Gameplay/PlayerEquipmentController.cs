using NotAVampireSurvivor.Core;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class PlayerEquipmentController : MonoBehaviour {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private PlayerEquipment playerEquipment;
        [SerializeField] private EnemySet enemySet;
    }
}