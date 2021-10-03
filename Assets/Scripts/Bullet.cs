using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Allegiance allegiance;
    
    public float damage = 25f;
    public float speed = 5f;
    public Vector2 dir;

    private Rigidbody2D _rb;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Target target;
        if (other.gameObject.TryGetComponent(out target))
        {
            if (target.allegiance == allegiance) return;
            target.health -= damage;
        }

        Explode();
    }

    public void Explode()
    {
        Destroy(gameObject);
    }
}
