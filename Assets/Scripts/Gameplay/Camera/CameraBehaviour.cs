using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    [RequireComponent(typeof(Camera))]
    public class CameraBehaviour : MonoBehaviour {
        [SerializeField] private Camera mainCamera;
        [SerializeField] private PlayerReference playerReference;
        [SerializeField] private CameraLimits cameraLimits;
        [SerializeField] private EventSO onRectChange;
        private EventListener rectChangeListener;

        private void Start() {
            rectChangeListener = new EventListener(onRectChange, () => cameraLimits.UpdateRectSize(mainCamera));
            rectChangeListener.StartListeningEvent();
        }

        private void LateUpdate() {
            MoveTowardsPlayer();
            cameraLimits.UpdatePosition(transform.position);
        }

        private void MoveTowardsPlayer() {
            if (playerReference.Value == null)
                return;
            Vector3 playerPosition = playerReference.Value.transform.position;
            transform.position = new Vector3(playerPosition.x, playerPosition.y, transform.position.z);
        }

        private void OnDestroy() {
            rectChangeListener.StopListeningEvent();
        }
    }
}
