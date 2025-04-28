using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class ProjectilePool : ObjectPool<Projectile> {
        [SerializeField] protected Projectile prefab;
        protected override Projectile ObjectPrefab => prefab;

        protected override void ExpandPool() { ExpandPoolByCurrentSize(); }
    }
}
