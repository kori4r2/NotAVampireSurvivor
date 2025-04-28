using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class ProjectileInfo {
        public Vector3? targetPosition = null;
        public Vector3 spawnPosition = Vector3.zero;
        public bool shouldDestroy = false;
        public int hitCount = 0;
        public float duration = 0;

        public ProjectileInfo() { }
    }
}
