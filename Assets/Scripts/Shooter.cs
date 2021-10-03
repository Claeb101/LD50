using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject bulletPf;
    public Transform shootPoint;

    public GameObject gunGfx;

    public float lookRotationSpeed = 1f;
    public float moveSpeed = 1f;
    
    public float range = 2f;
    public float shootSpeed = 5f;
    public float shootCooldown = 1f;

    private Target _target;
    [SerializeField]
    private GameObject target;
    private Rigidbody2D _rb;
    private Animator _animator;
    
    private bool _canShoot = true;

    // Start is called before the first frame update
    void Start()
    {
        _target = GetComponent<Target>();
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_target.health <= 0f)
        {
            Die();
        }

        RecalcTarget();
        
        if (target)
        {
            Vector2 dir = target.transform.position - transform.position;
            if (dir.magnitude > range)
            {
                // move to target
                _rb.velocity = dir.normalized * moveSpeed;
                _animator.SetBool("IsRunning", true);
            }
            else
            {
                // stop moving and shoot if ready
                _rb.velocity = Vector2.zero;
                if (_canShoot) StartCoroutine(Shoot());
                _animator.SetBool("IsRunning", false);
            }

            gunGfx.transform.rotation = Quaternion.Euler(new Vector3(0, 0, Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg));
            
            if (dir.x < 0)
            {
                foreach (var sprite in  GetComponentsInChildren<SpriteRenderer>())
                {
                    sprite.flipX = true;
                }

                SpriteRenderer gunSprite = gunGfx.GetComponent<SpriteRenderer>();
                gunSprite.flipX = false;
                gunSprite.flipY = true;
            }
        }
        else
        {
            // idle behaviour
            _rb.velocity = Vector2.zero;
            _animator.SetBool("IsRunning", false);
        }
    }
    
    void RecalcTarget()
    {
        float minDist = Single.MaxValue;
        foreach(var troop in FindObjectsOfType<Target>())
        {
            if (troop.allegiance != _target.allegiance)
            {
                float dist = (troop.transform.position - transform.position).sqrMagnitude;
                if (dist < minDist)
                {
                    minDist = dist;
                    target = troop.gameObject;
                }
            }
        }
    }

    IEnumerator Shoot()
    {
        if (!_canShoot) yield return null;
        
        Bullet bullet = Instantiate(bulletPf, shootPoint.position, Quaternion.identity, transform).GetComponent<Bullet>();
        bullet.allegiance = _target.allegiance;
        bullet.dir = (target.transform.position - transform.position).normalized;
        bullet.speed = shootSpeed;
        
        _canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        _canShoot = true;

    }
    
    public void Die()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
