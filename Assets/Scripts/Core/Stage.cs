using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [CreateAssetMenu(menuName = "VampSurvivor/Stage")]
    public class Stage : ScriptableObject {
        [SerializeField] private string levelName;
        public string LevelName => levelName;
        [SerializeField] private Sprite preview;
        public Sprite Preview => preview;
        [SerializeField] private Wave[] waves;
        public Wave[] Wave => waves;
    }
}
