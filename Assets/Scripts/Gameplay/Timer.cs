using Toblerone.Toolbox;
using UnityEngine;

namespace NotAVampireSurvivor.Gameplay {
    public class Timer : MonoBehaviour {
        [SerializeField] private FloatVariable timer;
        [SerializeField] private BoolVariable isPaused;

        private void Awake() {
            timer.Value = 0;
        }

        private void Update() {
            if (isPaused.Value) return;

            timer.IncrementValue(Time.deltaTime);
        }
    }
}