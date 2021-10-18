using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public float chainExplodeDelay = 0.2f;
    public GameObject barrelPf;

    public int cols, rows;

    public float colSep, rowSep;
    private bool _exploded;

    private void Start()
    {
        _exploded = false;
    }

    public void Generate()
    {
        for (int i = 0; i < cols; i++)
        {
            for (int j = 0; j < rows; j++)
            {
                float xi = colSep*(i - (cols / 2 - 1));
                float yi = rowSep*(j - (rows / 2 - 1));
                Instantiate(barrelPf, transform.position + new Vector3(xi, yi), Quaternion.identity, transform);
            }
        }
    }

    public void Explode(Barrel barrel)
    {
        if (!_exploded)
        {
            Debug.Log("explode first time");
            _exploded = true;
            StartCoroutine(ExplodeBarrels(barrel));
        }
    }
    public IEnumerator ExplodeBarrels(Barrel src)
    {
        Debug.Log("explode barrels");
        FindObjectOfType<GameManager>().OnLose();
        
        foreach (
            var barrel in GetComponentsInChildren<Barrel>().OrderBy(
                b => (b.transform.position-src.transform.position).sqrMagnitude
            )
        )
        {
            if (barrel && !barrel.exploded)
            {
                barrel.Explode();
                yield return new WaitForSeconds(chainExplodeDelay);
            }
        }
    }
}
