using System.Collections.Generic;
using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class Projectile : PoolableManagedBehaviour {
        public bool IsActive { get; protected set; }
        [SerializeField] protected List<ProjectileBehaviour> behaviours = new List<ProjectileBehaviour>();
        [SerializeField] protected RuntimeSet<Projectile> projectilesSet;
        protected Transform target = null;
        protected ProjectileInfo projectileInfo = new ProjectileInfo();

        public override void ResetObject() {
            InitializeProjectile();
        }

        public virtual void InitializeProjectile() {
            projectileInfo = new ProjectileInfo();
            projectileInfo.spawnPosition = transform.position;
        }

        public override void ManagedUpdate(float deltaTime) {
            if (target != null)
                projectileInfo.targetPosition = target.position;
            projectileInfo.duration += deltaTime;
            foreach (ProjectileBehaviour behaviour in behaviours)
                behaviour.Update(projectileInfo, deltaTime);
            if (projectileInfo.shouldDestroy)
                onDestroyed.Invoke(this);
        }

        protected override void AddToRuntimeSet() {
            projectilesSet.AddElement(this);
        }

        protected override void RemoveFromRuntimeSet() {
            projectilesSet.RemoveElement(this);
        }
    }
}
