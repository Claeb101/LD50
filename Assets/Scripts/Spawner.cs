using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    public GameObject spawnPf;

    public float delayExpDec = 0.75f;
    public float delay = 5f;
    public float delayRand = 2f;
    public float spawnWidth, spawnHeight;

    private bool _canSpawn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (_canSpawn) StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        if (!_canSpawn) yield return null;

        Vector3 spawnPos = new Vector3(Random.Range(-spawnHeight/2, spawnHeight/2), Random.Range(-spawnWidth/2, spawnWidth/2));
        Instantiate(spawnPf, spawnPos+transform.position, Quaternion.identity, transform);
        delay *= delayExpDec;
        
        _canSpawn = false;
        yield return new WaitForSeconds(delay + Random.Range(delay*(1-delayRand), delay*delayRand));
        _canSpawn = true;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, new Vector3(spawnWidth, spawnHeight));
    }
}
