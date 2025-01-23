using UnityEngine;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class CanvasGroupController : MonoBehaviour {
        [SerializeField] protected Selectable firstItem;
        [SerializeField] protected bool resetOnActivation;
        [SerializeField] protected CanvasGroup canvasGroup;
        [SerializeField] protected CanvasGroupReference reference;
        [SerializeField] protected InputMapSwitcher inputSwitcher;
        protected Selectable currentSelection;

        protected void Awake() {
            currentSelection = firstItem;
            reference.Value = this;
            Deactivate();
        }

        protected void OnDestroy() {
            if (reference.Value == this)
                reference.Value = null;
        }

        public void Activate() { Activate(false); }
        public void Activate(bool forceReset) {
            inputSwitcher.SwitchToMap();
            canvasGroup.gameObject.SetActive(true);
            canvasGroup.interactable = true;
            SelectableItem.SelectionChanged.AddListener(UpdateSelection);
            if (forceReset || resetOnActivation)
                firstItem.Select();
            else
                currentSelection.Select();
        }

        public void Deactivate() { Deactivate(true); }
        public void Deactivate(bool hideGroup) {
            if (hideGroup)
                canvasGroup.gameObject.SetActive(false);
            else
                canvasGroup.interactable = false;
            SelectableItem.SelectionChanged.RemoveListener(UpdateSelection);
        }

        protected void UpdateSelection(Selectable selectable) {
            currentSelection = selectable;
        }
    }
}
