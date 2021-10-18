using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public GameObject explodeFX;
    private Target _target;

    private GameManager _manager;

    public bool exploded = false;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.health <= 0f) Explode();
    }

    public void Explode()
    {
        Instantiate(explodeFX, transform.position, Quaternion.identity);
        exploded = true;

        GetComponentInParent<BarrelSpawner>().Explode(this);

        Destroy(gameObject);
    }
    
    
}
