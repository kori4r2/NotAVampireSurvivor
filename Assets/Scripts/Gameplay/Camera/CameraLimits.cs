using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    [CreateAssetMenu(menuName = "VampSurvivor/CameraLimits")]
    public class CameraLimits : ScriptableObject {
        [SerializeField, Range(0, 100f)] private float marginSize = 0;
        private Vector2 cameraPosition = Vector2.zero;
        private Rect viewRect = Rect.zero;

        private void Awake() {
            marginSize = Mathf.Max(0, marginSize);
        }

        public void UpdatePosition(Vector3 position) {
            cameraPosition.x = position.x;
            cameraPosition.y = position.y;
        }

        public void UpdateRectSize(Camera camera) {
            UpdatePosition(camera.transform.position);
            viewRect.position = cameraPosition;
            viewRect.min = CameraUtils.GetWorldSpaceCameraMinPosition(camera) - cameraPosition;
            viewRect.max = CameraUtils.GetWorldSpaceCameraMaxPosition(camera) - cameraPosition;
        }

        public bool IsInsideLimits(Vector3 position) {
            if (position.y < cameraPosition.y - viewRect.yMin)
                return false;
            if (position.y > cameraPosition.y + viewRect.yMax)
                return false;
            if (position.x < cameraPosition.x - viewRect.xMin)
                return false;
            if (position.x > cameraPosition.x + viewRect.xMax)
                return false;
            return true;
        }

        public bool IsInsideMargins(Vector3 position) {
            if (position.y < cameraPosition.y - viewRect.yMin - marginSize)
                return false;
            if (position.y > cameraPosition.y + viewRect.yMax + marginSize)
                return false;
            if (position.x < cameraPosition.x - viewRect.xMin - marginSize)
                return false;
            if (position.x > cameraPosition.x + viewRect.xMax + marginSize)
                return false;
            return true;
        }
    }
}
