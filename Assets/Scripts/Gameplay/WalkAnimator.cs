using UnityEngine;
using AnimationInfo = NotAVampireSurvivor.Core.AnimationInfo;

namespace NotAVampireSurvivor.Gameplay {
    [System.Serializable]
    public class WalkAnimator {
        private enum WalkAnimations {
            Idle,
            Walking
        }

        [SerializeField] private SpriteRenderer spriteRenderer;
        private AnimationInfo idleAnimation;
        private AnimationInfo walkAnimation;
        private WalkAnimations selectedAnimation = WalkAnimations.Idle;
        private AnimationInfo ActiveAnimationInfo => selectedAnimation switch {
            WalkAnimations.Idle => idleAnimation,
            WalkAnimations.Walking => walkAnimation,
            _ => throw new System.NotImplementedException(),
        };
        private float animationTime = 0;

        public void Init(AnimationInfo idle, AnimationInfo walk) {
            idleAnimation = idle;
            walkAnimation = walk;
            selectedAnimation = WalkAnimations.Idle;
        }

        public void Update(float deltaTime) {
            animationTime += deltaTime;
            spriteRenderer.sprite = ActiveAnimationInfo.GetSprite(animationTime);
        }

        public void SetVelocity(Vector2 velocity) {
            if (velocity.magnitude > float.Epsilon)
                selectedAnimation = WalkAnimations.Walking;
            else
                selectedAnimation = WalkAnimations.Idle;
            if (velocity.x > float.Epsilon)
                spriteRenderer.flipX = true;
            else if (velocity.x < -float.Epsilon)
                spriteRenderer.flipX = false;
        }
    }
}
