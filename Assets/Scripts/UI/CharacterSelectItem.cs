using NotAVampireSurvivor.Core;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class CharacterSelectItem : SelectableItem {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private Character character;
        [SerializeField] private Image characterSprite;

        private void OnValidate() {
            if (characterSprite)
                characterSprite.sprite = character == null ? null : character.Sprite;
        }

        public override void OnSelect(BaseEventData eventData) {
            runSettings.Character = character;
            base.OnSelect(eventData);
        }
    }
}
