using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(FenceSpawner))]
public class FenceSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            ((FenceSpawner)target).Generate();
        }
    }
}