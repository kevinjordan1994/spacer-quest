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

    void Start()
    {
        if (shooter.gameObject.name == "Enemy_Corrupted_Vessel")
        {
            transform.SetParent(null);
            Destroy(gameObject, shooter.GetProjectileLifeTime());
        }
        else
        {
            FindObjectOfType<AudioPlayer>().PlaySeekerSFX();
        }
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
