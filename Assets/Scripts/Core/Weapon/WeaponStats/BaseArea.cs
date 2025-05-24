using System;
using UnityEngine;

namespace NotAVampireSurvivor.Core {
    [Serializable]
    public class BaseArea : WeaponFloatStat {
        private const float maxBaseArea = 100;

        public override float ClampValue(float total) {
            return Mathf.Clamp(total, 0, maxBaseArea);
        }
    }
}