using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Run Settings")]
    public class RunSettings : ScriptableObject {
        [SerializeField] private Stage stage;
        public Stage Stage { get => stage; set => stage = value; }
        [SerializeField] private Character character;
        public Character Character { get => character; set => character = value; }
    }
}
