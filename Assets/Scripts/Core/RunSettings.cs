using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Run Settings")]
    public class RunSettings : ScriptableObject {
        [SerializeField] private Stage stage;
        public Stage Stage { get => stage; set => stage = value; }
        [SerializeField] private Character character;
        public Character Character {
            get => character;
            set {
                if (character == value)
                    return;
                character = value;
                playerStats.ResetAllBoosts();
                if (character != null)
                    character.ApplyInitialStats();
                characterChanged.Invoke(value);
            }
        }
        [SerializeField] private PlayerStats playerStats;
        public PlayerStats RunStats => playerStats;
        private UnityEvent<Character> characterChanged = new UnityEvent<Character>();

        public void ClearCharacterSelection() { Character = null; }

        public void ObserveCharacterSelection(UnityAction<Character> callback) {
            characterChanged.AddListener(callback);
        }

        public void RemoveCharacterSelectionObserver(UnityAction<Character> callback) {
            characterChanged.RemoveListener(callback);
        }

        public void RemoveAllCharacterSelectionObservers() {
            characterChanged.RemoveAllListeners();
        }
    }
}
