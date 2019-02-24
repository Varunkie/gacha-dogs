using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#else
using System;
#endif

public class FlagInEditorAttribute
#if UNITY_EDITOR
    : PropertyAttribute
#else
    : Attribute
#endif
{
    public FlagInEditorAttribute() { }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(FlagInEditorAttribute))]
public class FlagInEditorDrawer : PropertyDrawer
{
    public override void OnGUI(Rect _position, SerializedProperty _property, GUIContent _label)
    {
        EditorGUI.showMixedValue = _property.hasMultipleDifferentValues;
        // Change check is needed to prevent values being overwritten during multiple-selection
        EditorGUI.BeginChangeCheck();
        int newValue = EditorGUI.MaskField(_position, _label, _property.intValue, _property.enumNames);
        if (EditorGUI.EndChangeCheck())
        {
            _property.intValue = newValue;
        }
    }
}
#endif