using UnityEngine;
using Toblerone.Toolbox;
using NotAVampireSurvivor.Core;
using UnityEngine.InputSystem;

namespace NotAVampireSurvivor.Gameplay {
    public class Player : MonoBehaviour {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private FloatVariable hp;
        [SerializeField] private BoolVariable isGamePaused;
        private VariableObserver<bool> pauseObserver;
        [SerializeField] private PlayerReference reference;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody2D rigid2D;
        [SerializeField] private InputActionReference movementAction;
        public StatList Stats { get; private set; } = new StatList();
        private Movable2D movable;
        private WalkAnimator walkAnimator;
        private Vector2 direction;
        private static readonly float COS_45 = Mathf.Cos(Mathf.PI / 4);
        private static readonly float COS_22_5 = Mathf.Cos(Mathf.PI / 8);

        private void Awake() {
            movable = new Movable2D(rigid2D);
            movable.AllowDynamicMovement();
            movementAction.action.performed += ProcessMovementInput;
            walkAnimator = new WalkAnimator(animator);
            pauseObserver = new VariableObserver<bool>(isGamePaused, OnPauseChange);
            pauseObserver.StartWatching();
        }

        private void ProcessMovementInput(InputAction.CallbackContext context) {
            Vector2 input = context.ReadValue<Vector2>();
            movable.SetVelocity(input * Stats.Speed);
            if (input == Vector2.zero)
                return;
            direction = ApplyAxisRestriction(input);
            walkAnimator.UpdateDirection(direction);
        }

        private Vector2 ApplyAxisRestriction(Vector2 input) {
            if (input.x > COS_22_5)
                return Vector2.right;
            if (input.y > COS_22_5)
                return Vector2.up;
            if (input.x < -COS_22_5)
                return Vector2.left;
            if (input.y < -COS_22_5)
                return Vector2.down;
            return new Vector2(
                input.x > 0 ? COS_45 : -COS_45,
                input.y > 0 ? COS_45 : -COS_45
            );
        }

        private void OnPauseChange(bool isPaused) {
            if (isPaused) {
                movable.BlockMovement();
            } else {
                movable.AllowDynamicMovement();
            }
        }

        private void OnDestroy() {
            pauseObserver.StopWatching();
        }

        private void Update() {
            if (isGamePaused.Value)
                return;
            walkAnimator.SetSpeed(rigid2D.velocity.magnitude);
        }

        private void FixedUpdate() {
            movable.UpdateMovable();
        }
    }
}
