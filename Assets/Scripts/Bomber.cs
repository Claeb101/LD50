using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Bomber : MonoBehaviour
{
    public GameObject deathFX;
    public float damage = 100f;
    public float explodeRad = 0.5f;
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
        if(_target.health <= 0) Explode();
        
        _rb.velocity = dir * moveSpeed;
        bomberGfx.transform.Rotate(0, 0, -Mathf.Sign(dir.x)*rotateSpeed*Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        _target.health = 0;
    }

    public void Explode()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, explodeRad);
        foreach (Collider2D col in colliders)
        {
            Target target;
            if (col.gameObject.TryGetComponent(out target))
            {
                if (target.allegiance == _target.allegiance) continue;
                target.health -= damage;
            }
        }
        
        Debug.Log(gameObject.name + " is exploding near " + colliders.Length + " colliders");
        Instantiate(deathFX, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, explodeRad);
    }
}
