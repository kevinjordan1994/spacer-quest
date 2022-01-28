using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField] int damage = 10;
    [SerializeField] bool isPlayerBullet = false;

    void Start()
    {
        if (isPlayerBullet)
        {
            damage = FindObjectOfType<Player>().GetPlayerDamage();
        }
    }

    public int GetDamage()
    {
        return damage;
    }

    public void Hit()
    {
        Destroy(gameObject);
    }
}
