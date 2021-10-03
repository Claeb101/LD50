using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public float damage = 100f;

    public float moveSpeed;
    public float rotateSpeed = 1f;
    public Vector2 dir;
    
    private Rigidbody2D _rb;

    public SpriteRenderer bomberGfx;

    private Target _target;
    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _rb = GetComponent<Rigidbody2D>();
        
        if(dir.x < 0) bomberGfx.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        _rb.velocity = dir * moveSpeed;
        bomberGfx.transform.Rotate(0, 0, -Mathf.Sign(dir.x)*rotateSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Target target;
        if (other.gameObject.TryGetComponent(out target))
        {
            if (target.allegiance != _target.allegiance)
            {
                target.health -= damage;
            }
        }

        _target.health -= 100;
        Explode();
    }

    public void Explode()
    {
        Debug.Log("Exploding Bomber");
        Destroy(gameObject);
    }
}
