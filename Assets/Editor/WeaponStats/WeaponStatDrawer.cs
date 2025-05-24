using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    public abstract class WeaponStatDrawer<T> : PropertyDrawer where T : WeaponStat {
        private SerializedProperty value;
        protected T stat;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            value = property.FindPropertyRelative("value");
            stat = property.boxedValue as T;
            value.floatValue = GetNewValue(position, label);
            EditorGUI.EndProperty();
        }

        protected abstract float GetNewValue(Rect position, GUIContent label);
    }
}