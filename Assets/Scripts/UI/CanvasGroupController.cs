using Toblerone.Toolbox;
using UnityEngine;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    public class CanvasGroup : MonoBehaviour {
        [SerializeField] protected Selectable firstItem;
        [SerializeField] protected bool resetOnActivation;
        [SerializeField] protected CanvasGroup canvasGroup;
        [SerializeField] protected InputMapSwitcher inputSwitcher;
        [SerializeField] protected EventSO activationEvent;
        [SerializeField] protected EventSO deactivationEvent;
        protected EventListener activationListener;
        protected EventListener deactivationListener;
        protected Selectable currentSelection;

        protected void Awake() {
            activationListener = new EventListener(activationEvent, Activate);
            activationListener.StartListeningEvent();
            deactivationListener = new EventListener(deactivationEvent, Deactivate);
            deactivationListener.StartListeningEvent();
            currentSelection = firstItem;
        }

        protected void OnDestroy() {
            activationListener.StopListeningEvent();
            deactivationListener.StopListeningEvent();
        }

        public void Activate() {
            inputSwitcher.SwitchToMap();
            SelectableItem.SelectionChanged.AddListener(UpdateSelection);
            if (resetOnActivation)
                firstItem.Select();
            else
                currentSelection.Select();
        }

        public void Deactivate() {
            SelectableItem.SelectionChanged.RemoveListener(UpdateSelection);
        }

        protected void UpdateSelection(Selectable selectable) {
            currentSelection = selectable;
        }
    }
}
