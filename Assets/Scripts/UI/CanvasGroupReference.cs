using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.UI {
    [CreateAssetMenu(menuName = "VampSurvivor/CanvasGroupReference")]
    public class CanvasGroupReference : GenericVariable<CanvasGroupController> {
        public void Activate() {
            value.Activate(false);
        }

        public void ActivateForceReset(bool forceReset) {
            value.Activate(forceReset);
        }

        public void Deactivate() {
            value.Deactivate(true);
        }

        public void DeactivateHideGroup(bool hideGroup) {
            value.Deactivate(hideGroup);
        }
    }
}
