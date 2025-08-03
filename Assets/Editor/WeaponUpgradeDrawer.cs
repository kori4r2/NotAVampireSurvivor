using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(WeaponUpgrade))]
    public class WeaponUpgradeDrawer : PropertyDrawer {
        private const float margin = 5f;
        private SerializedProperty statIndex;
        private SerializedProperty increase;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            return margin + 2 * EditorGUIUtility.singleLineHeight;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            statIndex = property.FindPropertyRelative("statIndex");
            increase = property.FindPropertyRelative("increase");
            position.height = EditorGUIUtility.singleLineHeight;
            EditorGUI.PropertyField(position, statIndex);
            position.y += EditorGUIUtility.singleLineHeight + margin;
            increase.floatValue = (WeaponStatsEnum)statIndex.intValue switch {
                WeaponStatsEnum.Amount or WeaponStatsEnum.Damage =>
                    EditorGUI.IntField(position, increase.displayName, Mathf.RoundToInt(increase.floatValue)),
                WeaponStatsEnum.Area or WeaponStatsEnum.Cooldown or WeaponStatsEnum.Duration =>
                    EditorGUI.FloatField(position, increase.displayName, increase.floatValue),
                _ => 0,
            };
            EditorGUI.EndProperty();
        }
    }
}