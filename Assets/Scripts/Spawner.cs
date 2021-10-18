using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class SpawnerOption
{
    public GameObject spawnPf;
    public float freq;
}

public class Spawner : MonoBehaviour
{
    public List<SpawnerOption> spawnPfs;
    public AnimationCurve delayOverWaves;
    public AnimationCurve sizeOverWaves;
    public float spawnWidth, spawnHeight;

    [SerializeField] private int wave = 0;
    private bool _canSpawn = true;

    private void Update()
    {
        if (_canSpawn) StartCoroutine(SpawnWave());
    }

    IEnumerator SpawnWave()
    {
        _canSpawn = false;

        for (int i = 0; i < sizeOverWaves.Evaluate(wave); i++)
        {
            Spawn();
        }
        
        wave++;
        
        yield return new WaitForSeconds(delayOverWaves.Evaluate(wave));
        _canSpawn = true;
    }
    
    void Spawn()
    {
        GameObject spawnPf = null;
        float v = Random.value, sum = 0f;
        foreach(SpawnerOption option in spawnPfs)
        {
            sum += option.freq;
            if (v < sum)
            {
                spawnPf = option.spawnPf;
                break;
            }
        }
        
        
        Vector3 spawnPos = new Vector3(Random.Range(-spawnWidth/2, spawnWidth/2), Random.Range(-spawnHeight/2, spawnHeight/2));
        Instantiate(spawnPf, spawnPos+transform.position, Quaternion.identity, transform);
        Debug.Log("Spawned " + spawnPf.name + " at " + (spawnPos+transform.position));
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnWidth, spawnHeight));
    }
}