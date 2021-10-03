using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelSpawner : MonoBehaviour
{
    public GameObject barrelPf;

    public int cols, rows;

    public float colSep, rowSep;
    // Start is called before the first frame update
    void Start()
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
