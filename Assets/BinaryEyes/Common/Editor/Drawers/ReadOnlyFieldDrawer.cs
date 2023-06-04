using BinaryEyes.Common.Attributes;
using UnityEngine;
using UnityEditor;

namespace BinaryEyes.Common.Drawers
{
    [CustomPropertyDrawer(typeof(ReadOnlyFieldAttribute))]
    public class ReadOnlyFieldAttributeDrawer
        : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var previousGuiState = GUI.enabled;
            GUI.enabled = false;
            EditorGUI.PropertyField(position, property, label);

            GUI.enabled = previousGuiState;
        }
    }
}