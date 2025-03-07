using UnityEngine;
using Toblerone.Toolbox.SceneManagement;
using NotAVampireSurvivor.Core;
using UnityEngine.Events;
using Toblerone.Toolbox;

namespace NotAVampireSurvivor.SceneChange {
    public class TransitionController : SceneChangeController {
        [Header("Persistent Objects")]
        [SerializeField] private RunSettings runSettings;
        [Header("Scene References")]
        [SerializeField] private GameObject rootObject;
        [SerializeField] private SceneChangeControllerVariable reference;
        [Header("Events")]
        [SerializeField] private EventSO transitionInStarted;
        private EventListener inPreparedListener;
        [SerializeField] private EventSO transitionInFinished;
        private EventListener inFinishedListener;
        [SerializeField] private EventSO transitionOutStarted;
        private EventListener outPreparedListener;
        [SerializeField] private EventSO transitionOutFinished;
        private EventListener outFinishedListener;
        private UnityAction onPrepared;
        private UnityAction onFinished;

        private void Awake() {
            reference.Value = this;
            inPreparedListener = new EventListener(transitionInFinished, () => onPrepared.Invoke());
            inPreparedListener.StartListeningEvent();
            outPreparedListener = new EventListener(transitionOutFinished, () => {
                onFinished.Invoke();
                rootObject.SetActive(false);
            });
            outPreparedListener.StartListeningEvent();
        }

        private void OnDestroy() {
            inPreparedListener.StopListeningEvent();
            outPreparedListener.StopListeningEvent();
        }

        public override void Activate(UnityAction onPrepared) {
            rootObject.SetActive(true);
            this.onPrepared = onPrepared;
            transitionInStarted.Raise();
        }

        public override void Deactivate(UnityAction onFinished) {
            this.onFinished = onFinished;
            transitionOutStarted.Raise();
        }

        public override void DisplaySceneLoadOperation(AsyncOperation loadOperation) { }
    }
}
