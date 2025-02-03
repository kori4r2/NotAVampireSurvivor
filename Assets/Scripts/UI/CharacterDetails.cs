using NotAVampireSurvivor.Core;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class CharacterDetails : MonoBehaviour {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private Image characterSprite;
        [SerializeField] private TextMeshProUGUI characterName;
        [SerializeField] private TextMeshProUGUI characterDescription;

        private void Awake() {
            runSettings.ObserveCharacterSelection(OnCharacterSelected);
            OnCharacterSelected(runSettings.Character);
        }


        private void OnCharacterSelected(Character character) {
            if (character == null) {
                gameObject.SetActive(false);
                return;
            }
            gameObject.SetActive(true);
            characterSprite.sprite = character.Sprite;
            characterName.text = character.Name;
            characterDescription.text = character.Description;
        }

        private void OnDestroy() {
            runSettings.RemoveCharacterSelectionObserver(OnCharacterSelected);
        }
    }
}
