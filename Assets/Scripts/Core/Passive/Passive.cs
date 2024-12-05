using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Passive")]
    public class Passive : Item {
        [SerializeField] private PassiveLevel[] levelUps;
    }
}
