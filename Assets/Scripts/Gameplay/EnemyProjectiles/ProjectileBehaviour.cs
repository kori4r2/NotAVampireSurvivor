using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public abstract class ProjectileBehaviour : ScriptableObject {
        public abstract void Init(ProjectileInfo info);
        public abstract void Update(ProjectileInfo info, float deltaTime);
        public abstract void OnCollision(ProjectileInfo info);
    }
}
