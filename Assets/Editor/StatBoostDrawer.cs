using Toblerone.Toolbox.EditorScripts;
using NotAVampireSurvivor.Core;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(StatBoost))]
    public class StatBoostDrawer : PropertyDrawer {
        private RectManipulator rectManipulator = new RectManipulator();
        private SerializedProperty stat;
        private SerializedProperty increase;
        private const float indentSize = 10f;
        private const float paddingSize = 2f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            if (!property.isExpanded)
                return EditorGUIUtility.singleLineHeight;
            bool hasReference = property.FindPropertyRelative("stat")?.objectReferenceValue != null;
            return EditorGUIUtility.singleLineHeight * (hasReference ? 3 : 2) + paddingSize * (hasReference ? 2 : 1);
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
            rectManipulator.ResetToRect(position);
            rectManipulator.OffsetVerticalPosition(EditorGUIUtility.singleLineHeight);
            rectManipulator.SetHorizontalMargins(indentSize, 0);
            rectManipulator.SetSize(null, EditorGUIUtility.singleLineHeight);
            FindSerializedFieldProperties(property);
            EditorGUI.ObjectField(rectManipulator.GetRect(), stat);
            if (stat.objectReferenceValue != null) {
                DrawIncreaseField();
            }
        }

        private void FindSerializedFieldProperties(SerializedProperty property) {
            stat = property.FindPropertyRelative("stat");
            increase = property.FindPropertyRelative("increase");
        }

        private void DrawIncreaseField() {
            rectManipulator.OffsetVerticalPosition(EditorGUIUtility.singleLineHeight + paddingSize);
            Rect position = rectManipulator.GetRect();
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
