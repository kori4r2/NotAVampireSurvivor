using NotAVampireSurvivor.Core;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class StageSelectItem : SelectableItem {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private Stage stage;
        [SerializeField] private Image stageSprite;
        [SerializeField] private TextMeshProUGUI stageName;
        [SerializeField] private TextMeshProUGUI stageDescription;

        private void OnValidate() {
            if (stageSprite)
                stageSprite.sprite = stage == null ? null : stage.Preview;
            if (stageName)
                stageName.text = stage == null ? "Name" : stage.LevelName;
            if (stageDescription)
                stageDescription.text = stage == null ? "Description" : stage.Description;
        }

        public override void OnSelect(BaseEventData eventData) {
            runSettings.Stage = stage;
            base.OnSelect(eventData);
        }
    }
}
