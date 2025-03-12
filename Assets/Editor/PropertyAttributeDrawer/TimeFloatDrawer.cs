using NotAVampireSurvivor.Core;
using Toblerone.Toolbox.EditorScripts;
using UnityEditor;
using UnityEngine;

namespace NotAVampireSurvivor.Editor {
    [CustomPropertyDrawer(typeof(TimeFloat))]
    public class TimeFloatDrawer : PropertyDrawer {
        private int minutes = 0;
        private int seconds = 0;
        RectManipulator rectManipulator = new RectManipulator();
        private GUIStyle numbersStyle = EditorStyles.numberField;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            label.text = $"{label.text} (M:S)";
            EditorGUI.BeginProperty(position, label, property);
            if (property.propertyType != SerializedPropertyType.Float)
                throw new System.Exception("TimeFloat Attribute can only be applied to float fields");
            position = EditorGUI.PrefixLabel(position, label);
            EditorGUI.LabelField(position, "", EditorStyles.helpBox);
            LoadTimeValues(property.floatValue);
            DrawMinutesField(position);
            DrawSecondsField(position);
            SaveTimeValues(property);
            EditorGUI.EndProperty();
        }

        private void LoadTimeValues(float value) {
            float mod = value % 60;
            seconds = Mathf.FloorToInt(mod);
            minutes = Mathf.FloorToInt((value - mod) / 60f);
        }

        private void DrawMinutesField(Rect position) {
            rectManipulator.ResetToRect(position);
            rectManipulator.ApplyHorizontalAnchors(new Vector2(0, 0.5f));
            rectManipulator.SetHorizontalMargins(0f, 0f);
            numbersStyle.alignment = TextAnchor.MiddleRight;
            minutes = Mathf.Max(0, EditorGUI.IntField(rectManipulator.GetRect(), minutes, numbersStyle));
        }

        private void DrawSecondsField(Rect position) {
            rectManipulator.ResetToRect(position);
            rectManipulator.ApplyHorizontalAnchors(new Vector2(0.5f, 1f));
            rectManipulator.SetHorizontalMargins(0f, 0);
            Rect valueRect = rectManipulator.GetRect();
            numbersStyle.alignment = TextAnchor.MiddleLeft;
            float labelWidth = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 20f;
            seconds = EditorGUI.IntField(valueRect, ":", seconds, numbersStyle);
            if (seconds >= 60) {
                minutes += seconds / 60;
                seconds %= 60;
            } else if (seconds < 0) {
                minutes -= (seconds / 60) + 1;
                seconds += ((seconds / 60) + 1) * 60;
            }
            EditorGUIUtility.labelWidth = labelWidth;
        }

        private void SaveTimeValues(SerializedProperty property) {
            property.floatValue = Mathf.Max(0, (minutes * 60) + seconds);
        }
    }
}
