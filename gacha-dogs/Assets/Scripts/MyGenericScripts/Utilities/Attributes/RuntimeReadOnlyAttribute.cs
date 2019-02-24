using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#else
using System;
#endif

public class RuntimeReadOnlyAttribute
#if UNITY_EDITOR
    : PropertyAttribute
#else
    : Attribute
#endif
{
    public RuntimeReadOnlyAttribute() { }
}

#if UNITY_EDITOR
[CustomPropertyDrawer(typeof(RuntimeReadOnlyAttribute))]
public class RuntimeReadOnlyDrawer : PropertyDrawer
{
    public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
    {
        return EditorGUI.GetPropertyHeight(property, label, true);
    }

    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        if (Application.isPlaying)
            GUI.enabled = false;
        EditorGUI.PropertyField(position, property, label, true);
        if (Application.isPlaying)
            GUI.enabled = true;
    }
}
#endif