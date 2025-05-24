using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    public abstract class WeaponFloatStatDrawer<T> : WeaponStatDrawer<T> where T : WeaponFloatStat {
        protected override float GetNewValue(Rect position, GUIContent label) {
            return stat?.ClampValue(EditorGUI.FloatField(position, label, stat?.Value ?? 0)) ?? 0;
        }
    }
}