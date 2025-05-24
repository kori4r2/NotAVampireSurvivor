using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    public abstract class WeaponIntStatDrawer<T> : WeaponStatDrawer<T> where T : WeaponIntStat {
        protected override float GetNewValue(Rect position, GUIContent label) {
            return stat?.ClampValue(EditorGUI.IntField(position, label, Mathf.RoundToInt(stat?.Value ?? 0))) ?? 0;
        }
    }
}