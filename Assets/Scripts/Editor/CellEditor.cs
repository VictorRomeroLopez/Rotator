using UnityEditor;

[CustomEditor(typeof(Cell))]
public class CellEditor : Editor
{
    private SerializedObject _so;
    private SerializedProperty _directionsProperty;
    private SerializedProperty _cellsProperty;

    private void OnEnable()
    {
        Cell thisCell = target as Cell;
        _so = new SerializedObject(thisCell);
        _directionsProperty = _so.FindProperty("_directions");
        _cellsProperty = _so.FindProperty("_cells");
    }


    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        _so.Update();
        EditorGUILayout.PropertyField(_directionsProperty);
        EditorGUILayout.PropertyField(_cellsProperty);
        _so.ApplyModifiedProperties();
    }
}