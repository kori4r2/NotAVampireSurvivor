using Toblerone.Toolbox;
using UnityEngine;
using UnityEngine.Events;

namespace NotAVampireSurvivor.Gameplay {
    public abstract class PoolableManagedBehaviour : MonoBehaviour, IPoolableObject, IManagedBehaviour {
        public GameObject GameObject => gameObject;
        protected UnityEvent<PoolableManagedBehaviour> onDestroyed = new UnityEvent<PoolableManagedBehaviour>();

        public bool ShouldUpdate { get; protected set; }

        public void Despawn() {
            onDestroyed.Invoke(this);
        }

        public abstract void ManagedUpdate(float deltaTime);

        public abstract void ResetObject();

        public void SetDespawnCallback(UnityAction<IPoolableObject> callback) {
            onDestroyed.AddListener(obj => callback.Invoke(obj));
        }

        protected void OEnable() {
            AddToRuntimeSet();
        }

        protected abstract void AddToRuntimeSet();

        protected void OnDisable() {
            RemoveFromRuntimeSet();
        }

        protected abstract void RemoveFromRuntimeSet();
    }
}
