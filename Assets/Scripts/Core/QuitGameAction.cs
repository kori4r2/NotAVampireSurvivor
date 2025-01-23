using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/QuitAction")]
    public class QuitGameAction : ScriptableObject {
        public void QuitGame() {
#if UNITY_EDITOR
            EditorApplication.ExitPlaymode();
#else
            Application.Quit();
#endif
        }
    }
}
