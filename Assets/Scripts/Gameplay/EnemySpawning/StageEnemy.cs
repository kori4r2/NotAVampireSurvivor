using NotAVampireSurvivor.Core;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class StageEnemy : PoolableManagedBehaviour {
        [Header("References")]
        [SerializeField] protected PlayerReference playerReference;
        [SerializeField] protected EnemySet enemiesSet;
        [SerializeField] protected CameraLimits cameraLimits;
        [Header("Physics")]
        [SerializeField] protected Movable2D movable;
        [SerializeField] new protected Collider2D collider;
        [Header("Animation")]
        [SerializeField] protected SpriteRenderer spriteRenderer;
        [SerializeField, Range(0.1f, 2f)] protected float fadeTime;
        private const float fadeStart = 0.8f;
        protected IRuntimeSet<StageEnemy> enemyWaveSet = null;
        public bool IsDead => hp <= 0;
        private float hp = 0;
        public float SquareDistance { get; private set; } = float.MaxValue;
        private Enemy loadedEnemy;
        private float animationTimer;
        private float offScreenTimer;
        private const float offScreenTimeLimit = 2.5f;

        public override void ManagedUpdate(float deltaTime) {
            UpdateDistance();
            animationTimer += deltaTime;
            if (!IsDead) {
                CheckReposition(deltaTime);
                movable.SetVelocity(loadedEnemy.CalculateSpeed(transform.position, playerReference.Value?.transform));
                // Valid only because physics are calculated in Update for this project
                movable.UpdateMovable();
                spriteRenderer.sprite = loadedEnemy.Animation.GetSprite(animationTimer);
                return;
            }

            if (animationTimer > fadeTime) {
                Despawn();
                return;
            }

            SetOpacity(fadeStart * (1.0f - animationTimer / fadeTime));
            movable.SetVelocity(Vector2.zero);
            movable.UpdateMovable();
        }

        private void CheckReposition(float deltaTime) {
            Vector3 currentPosition = transform.position;
            if (cameraLimits.IsInsideLimits(currentPosition)) {
                offScreenTimer = 0;
                return;
            }

            if (cameraLimits.IsInsideMargins(currentPosition)) {
                offScreenTimer += deltaTime;
            } else {
                offScreenTimer = offScreenTimeLimit + 1;
            }

            if (offScreenTimer < offScreenTimeLimit) return;

            RepositionOnMargin();
            offScreenTimer = 0;
        }

        private void RepositionOnMargin() {
            PositionOnMargin(Random.value * 360);
        }

        public void PositionOnMargin(float angle) {
            Vector3 position = cameraLimits.GetBorderPosition(angle, cameraLimits.MarginSize * 0.5f);
            transform.position = position;
        }

        private void UpdateDistance() {
            SquareDistance = IsDead || !playerReference.Value ?
                float.MaxValue :
                (playerReference.Value.transform.position - transform.position).sqrMagnitude;
        }

        private void SetOpacity(float opacity) {
            opacity = Mathf.Clamp(opacity, 0, 1.0f);
            Color color = spriteRenderer.color;
            color.a = opacity;
            spriteRenderer.color = color;
        }

        public override void ResetObject() {
            collider.enabled = true;
            movable.AllowDynamicMovement();
            animationTimer = 0;
            ShouldUpdate = true;
        }

        public virtual void LoadRuntimeSet(IRuntimeSet<StageEnemy> runtimeSet) {
            enemyWaveSet = runtimeSet;
            if (isActiveAndEnabled && !runtimeSet.Contains(this)) runtimeSet.AddElement(this);
        }

        public void LoadEnemyInfo(Enemy enemyInfo) {
            loadedEnemy = enemyInfo;
            hp = enemyInfo.MaxHp;
        }

        public void DealDamage(float damage, float knockback) {
            KnockBack(knockback);
            hp -= damage;
            if (hp <= 0) Kill();
        }

        private void KnockBack(float value) {
            // TO DO
        }

        public void Kill() {
            DropLoot();
            Erase();
        }

        public void Erase() {
            collider.enabled = true;
            movable.BlockMovement();
            animationTimer = 0;
            hp = 0;
            SetOpacity(fadeStart);
        }

        protected void DropLoot() {
            // TO DO: Drops system
            // dropsManager.DropExp(baseExp, transform.position);
        }

        protected override void AddToRuntimeSet() {
            enemiesSet.AddElement(this);
            if (enemyWaveSet != null) enemyWaveSet.AddElement(this);
        }

        protected override void RemoveFromRuntimeSet() {
            enemiesSet.RemoveElement(this);
            if (enemyWaveSet != null) enemyWaveSet.RemoveElement(this);
        }
    }
}