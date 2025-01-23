using UnityEngine;
using UnityEngine.InputSystem;

namespace NotAVampireSurvivor.UI {
    public class NavigationInitializer : MonoBehaviour {
        [SerializeField] private CanvasGroupReference firstCanvasGroup;
        [SerializeField] private InputActionAsset actions;
        void Start() {
            actions.Enable();
            firstCanvasGroup.Activate();
        }
    }
}
