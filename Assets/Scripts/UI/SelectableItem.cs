using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace NotAVampireSurvivor.UI {
    [RequireComponent(typeof(Selectable))]
    public class SelectableItem : MonoBehaviour, ISelectHandler, IPointerEnterHandler {
        public static Selectable currentSelection;
        public static readonly UnityEvent<Selectable> SelectionChanged = new UnityEvent<Selectable>();
        protected Selectable selectable;

        protected void Awake() {
            selectable = GetComponent<Selectable>();
        }

        public void OnSelect(BaseEventData eventData) {
            currentSelection = selectable;
        }

        public void OnPointerEnter(PointerEventData eventData) {
            selectable.Select();
        }
    }
}
