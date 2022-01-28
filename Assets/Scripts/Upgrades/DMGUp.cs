using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DMGUp : MonoBehaviour
{   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<Player>().SetPlayerDamage(10);
            Destroy(gameObject);
        }
    }
}
