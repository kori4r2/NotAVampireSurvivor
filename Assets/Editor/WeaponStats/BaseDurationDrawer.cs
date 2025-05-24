using NotAVampireSurvivor.Core;
using UnityEditor;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(BaseDuration), true)]
    public class BaseDurationDrawer : WeaponFloatStatDrawer<BaseDuration> {
    }
}