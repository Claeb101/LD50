using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float delay = 1f;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DestroyRt());
    }
    
    private IEnumerator DestroyRt()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
