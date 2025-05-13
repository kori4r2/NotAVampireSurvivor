using UnityEngine;
using Toblerone.Toolbox;
using NotAVampireSurvivor.Core;
using UnityEngine.InputSystem;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Gameplay {
    public class Player : MonoBehaviour {
        [SerializeField] private RunSettings runSettings;
        [SerializeField] private FloatVariable hp;
        [SerializeField] private BoolVariable isGamePaused;
        private VariableObserver<bool> pauseObserver;
        [SerializeField] private PlayerReference reference;
        [SerializeField] private Speed speed;
        [SerializeField] private WalkAnimator walkAnimator;
        [SerializeField] private InputActionReference movementAction;
        [SerializeField] private Movable2D movable;
        [Header("Debug")]
        [SerializeField] private UnityEvent onAwake;
        private Vector2 direction;
        private static readonly float COS_45 = Mathf.Cos(Mathf.PI / 4);
        private static readonly float COS_22_5 = Mathf.Cos(Mathf.PI / 8);

        private void Awake() {
            reference.Value = this;
            movable.AllowDynamicMovement();
            movementAction.action.performed += ProcessMovementInput;
            movementAction.action.canceled += ProcessMovementInput;
            onAwake?.Invoke();
            pauseObserver = new VariableObserver<bool>(isGamePaused, OnPauseChange);
            pauseObserver.StartWatching();
            LoadCharacter(runSettings.Character);
        }

        private void LoadCharacter(Character character) {
            walkAnimator.Init(character.IdleAnimation, character.WalkAnimation);
        }

        private void ProcessMovementInput(InputAction.CallbackContext context) {
            Vector2 input = context.ReadValue<Vector2>();
            movable.SetVelocity(input * speed.Value);
            if (input == Vector2.zero)
                return;
            direction = ApplyAxisRestriction(input);
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
            if (reference.Value == this)
                reference.Value = null;
            pauseObserver.StopWatching();
            movementAction.action.performed -= ProcessMovementInput;
            movementAction.action.canceled -= ProcessMovementInput;
        }

        private void Update() {
            if (isGamePaused.Value)
                return;
            walkAnimator.SetVelocity(movable.CurrentVelocity);
            walkAnimator.Update(Time.deltaTime);
        }

        private void FixedUpdate() {
            movable.UpdateMovable();
        }
    }
}
