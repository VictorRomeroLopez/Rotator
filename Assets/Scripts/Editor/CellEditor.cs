using System;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Cell))]
public class CellEditor : Editor
{
    readonly GUIContent PreviousContent = new GUIContent("  <  ", "Type A to previous sprite");
    GUIStyle _style;
    private SerializedObject _serializedObject;
    private SerializedProperty _cellsProperty;
    
    private void OnEnable()
    {
        Cell thisCell = target as Cell;
        _serializedObject = serializedObject;
        _cellsProperty = _serializedObject.FindProperty("_cells");
        _style = new GUIStyle
        {
            alignment = TextAnchor.MiddleCenter
        };
    }

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        
        _serializedObject.Update();
        EditorGUILayout.PropertyField(_cellsProperty);
        
        if (GUILayout.Button("Clear"))
        {
            _cellsProperty.ClearArray();
        }
        if (GUILayout.Button("Add cells"))
        {
            Cell thisCell = target as Cell;
            thisCell.AddSelectedCells();
        }
        
        _serializedObject.ApplyModifiedProperties();

    }

    private void OnSceneGUI()
    {
        // SceneView sceneView = SceneView.currentDrawingSceneView;
        // Vector3 screenPosition = new Vector3(sceneView.position.x + sceneView.position.width,
        //     sceneView.position.y, 0);
        // screenPosition = Camera.current.ScreenToWorldPoint(screenPosition);
        // Rect rect = HandleUtility.WorldPointToSizedRect(screenPosition, PreviousContent, _style);
        // Handles.BeginGUI();
        // GUI.Button(rect, "<");
        // Handles.EndGUI();
    }
}