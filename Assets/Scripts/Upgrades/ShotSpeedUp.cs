using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotSpeedUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Shooter>().UpgradePlayerShotSpeed(5f);
            Destroy(gameObject);
        }
    }
}
