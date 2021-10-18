using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenceSpawner : MonoBehaviour
{
    public GameObject fencePf;
    public float sep = 0.5f;

    public int count = 8;
    
    public void Generate()
    {
        for (int i = 0; i < count; i++)
        {
            float xi = sep*(i - (count / 2 - 1));
            Instantiate(fencePf, transform.position + new Vector3(xi, 0, 0), Quaternion.identity, transform);
        }
    }

}
