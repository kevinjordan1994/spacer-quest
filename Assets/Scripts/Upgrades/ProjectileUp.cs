using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileUp : MonoBehaviour
{
    Player player;

    void Awake()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            GameObject currentProjectile = collision.GetComponent<Shooter>().GetProjectilePrefab();

            if (currentProjectile == player.GetWeaponFromPlayerList(0))
            {
                collision.GetComponent<Shooter>().SetProjectilePrefab(1);
            }
            else
            {
                collision.GetComponent<Shooter>().SetProjectilePrefab(2);
            }
            Destroy(gameObject);
        }
    }
}
