using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(BarrelSpawner))]
public class BarrelSpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        if (GUILayout.Button("Generate"))
        {
            ((BarrelSpawner)target).Generate();
        }
    }
}