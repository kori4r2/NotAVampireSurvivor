using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace NotAVampireSurvivor.Gameplay {
    public class PauseEventActivator : MonoBehaviour {
        [SerializeField] private InputActionReference pauseAction;
        [SerializeField] private UnityEvent onPause;

        private void Awake() {
            pauseAction.action.performed += OnPausePressed;
        }

        private void OnDestroy() {
            pauseAction.action.performed -= OnPausePressed;
        }

        private void OnPausePressed(InputAction.CallbackContext context) {
            onPause.Invoke();
        }
    }
}
