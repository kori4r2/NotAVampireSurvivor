using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class AnimationInfo {
        [SerializeField] private float duration;
        public float Duration => duration;
        [SerializeField] private Sprite[] sprites;
        public Sprite GetSprite(float time) {
            if (sprites == null || sprites.Length < 1)
                return null;
            if (time < 0)
                time += (1 + Mathf.CeilToInt(-time / duration)) * duration;
            return sprites[Mathf.FloorToInt(Mathf.Repeat(time, duration))];
        }
    }
}
