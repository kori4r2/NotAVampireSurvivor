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
        [SerializeField] protected UnityEvent serializedOnSelect = new UnityEvent();

        protected virtual void Awake() {
            selectable = GetComponent<Selectable>();
        }

        public virtual void OnSelect(BaseEventData eventData) {
            if (currentSelection != this)
                SelectionChanged.Invoke(selectable);
            currentSelection = selectable;
            serializedOnSelect?.Invoke();
        }

        public void OnPointerEnter(PointerEventData eventData) {
            selectable.Select();
        }
    }
}
