using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeekerBullet : MonoBehaviour
{
    [SerializeField] Shooter shooter;
    Rigidbody2D rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveBulletTowardsTarget();
    }

    void MoveBulletTowardsTarget()
    {
        Player target = FindObjectOfType<Player>();

        if (target != null)
        {
            Vector2 moveDirection = (target.transform.position - transform.position).normalized * shooter.GetProjectileSpeed();
            rb.velocity = new Vector2(moveDirection.x, moveDirection.y);
        }
    }
}
