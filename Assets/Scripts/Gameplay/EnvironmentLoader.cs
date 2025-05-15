using NotAVampireSurvivor.Core;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class EnvironmentLoader : MonoBehaviour {
        [SerializeField] private RunSettings runSettings;

        void Start() {
            if (runSettings.Stage == null)
                return;
            Instantiate(runSettings.Stage.Prefab, transform, false);
        }
    }
}
