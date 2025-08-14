using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    [CreateAssetMenu(menuName = "VampSurvivor/CameraLimits")]
    public class CameraLimits : ScriptableObject {
        [SerializeField, Range(0, 100f)] private float marginSize = 0;
        public float MarginSize => marginSize;
        private Vector2 cameraPosition = Vector2.zero;
        private Rect viewRect = Rect.zero;
        public float Width => viewRect.width;
        public float Height => viewRect.height;
        private float radius = 0;

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
            radius = Mathf.Sqrt(Height * Height + Width * Width) / 2f;
        }

        public bool IsInsideLimits(Vector3 position) {
            if (position.y < cameraPosition.y + viewRect.yMin) return false;
            if (position.y > cameraPosition.y + viewRect.yMax) return false;
            if (position.x < cameraPosition.x + viewRect.xMin) return false;
            if (position.x > cameraPosition.x + viewRect.xMax) return false;

            return true;
        }

        public bool IsInsideMargins(Vector3 position) {
            if (position.y < cameraPosition.y + viewRect.yMin - marginSize) return false;
            if (position.y > cameraPosition.y + viewRect.yMax + marginSize) return false;
            if (position.x < cameraPosition.x + viewRect.xMin - marginSize) return false;
            if (position.x > cameraPosition.x + viewRect.xMax + marginSize) return false;

            return true;
        }

        public Vector2 GetBorderPosition(float angle, float offset) {
            float sin = Mathf.Sin(angle * Mathf.Deg2Rad);
            float cos = Mathf.Cos(angle * Mathf.Deg2Rad);
            Vector2 position;
            if (sin * sin * radius * radius > (Height * Height) / 4.0f) {
                // up/down
                position = new Vector2(0, (sin > 0 ? 1 : -1) * offset);
                position.x += radius * cos;
                position.y += (sin > 0 ? 1 : -1) * Height / 2f;
            } else {
                // left/right
                position = new Vector2((cos > 0 ? 1 : -1) * offset, 0);
                position.x += (cos > 0 ? 1 : -1) * Width / 2f;
                position.y += radius * sin;
            }
            position += cameraPosition;
            return position;
        }
    }
}