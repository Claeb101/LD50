using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Spawner))]
public class SpawnerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();
        Spawner spawner = (Spawner)target;
        if (GUILayout.Button("Normalize"))
        {
            float sum = 0;
            foreach (SpawnerOption option in spawner.spawnPfs)
            {
                sum += option.freq;
            }

            foreach (SpawnerOption option in spawner.spawnPfs)
            {
                option.freq /= sum;
            }
        }
    }
}