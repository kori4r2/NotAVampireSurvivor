using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class WalkAnimator {
        private readonly int WALK_X_FLAG = Animator.StringToHash("walkX");
        private readonly int WALK_Y_FLAG = Animator.StringToHash("walkY");
        private readonly int WALK_SPEED_FLAG = Animator.StringToHash("walkSpeed");

        private Animator animator;

        public WalkAnimator(Animator animator) {
            this.animator = animator;
        }

        public void UpdateDirection(Vector2 direction) {
            animator.SetFloat(WALK_X_FLAG, direction.x);
            animator.SetFloat(WALK_Y_FLAG, direction.y);
        }

        public void SetSpeed(float speed) {
            animator.SetFloat(WALK_SPEED_FLAG, speed);
        }
    }
}
