using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(StatBoost))]
    public class StatBoostDrawer : PropertyDrawer {
        private SerializedProperty stat;
        private SerializedProperty increase;
        private const float indentSise = 10f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            if (!property.isExpanded)
                return EditorGUIUtility.singleLineHeight;
            bool hasReference = property.FindPropertyRelative("stat")?.objectReferenceValue != null;
            return EditorGUIUtility.singleLineHeight * (hasReference ? 3 : 2);
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            EditorGUI.BeginProperty(position, label, property);
            Rect foldoutRect = new Rect(position.position, new Vector2(position.size.x, EditorGUIUtility.singleLineHeight));
            property.isExpanded = EditorGUI.Foldout(foldoutRect, property.isExpanded, label);
            if (property.isExpanded) {
                DrawPropertyFields(position, property);
            }
            EditorGUI.EndProperty();
        }

        private void DrawPropertyFields(Rect position, SerializedProperty property) {
            position.position += new Vector2(indentSise, EditorGUIUtility.singleLineHeight);
            FindSerializedFieldProperties(property);
            position.size = new Vector2(position.size.x - indentSise, EditorGUIUtility.singleLineHeight);
            EditorGUI.ObjectField(position, stat);
            if (stat.objectReferenceValue != null) {
                DrawIncreaseField(position);
            }
        }

        private void FindSerializedFieldProperties(SerializedProperty property) {
            stat = property.FindPropertyRelative("stat");
            increase = property.FindPropertyRelative("increase");
        }

        private void DrawIncreaseField(Rect position) {
            position.position += new Vector2(0, EditorGUIUtility.singleLineHeight);
            PlayerStat playerStat = stat.objectReferenceValue as PlayerStat;
            string unitIndicator = string.IsNullOrEmpty(playerStat.ValueDescription) ? "" : $" ({playerStat.ValueDescription})";
            string label = $"{increase.displayName}{unitIndicator}";
            if (stat.objectReferenceValue is TypedPlayerStat<int>) {
                increase.floatValue = EditorGUI.IntField(position, label, Mathf.RoundToInt(increase.floatValue));
            } else if (stat.objectReferenceValue is TypedPlayerStat<float>) {
                increase.floatValue = EditorGUI.FloatField(position, label, increase.floatValue);
            } else {
                EditorGUI.LabelField(position, "Unsupported PlayerStat type", EditorStyles.helpBox);
            }
        }
    }
}
