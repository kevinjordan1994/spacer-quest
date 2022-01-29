using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthUp : MonoBehaviour
{
    [SerializeField] int healthIncreaseAmount = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            collision.GetComponent<Health>().SetHealthAmount(healthIncreaseAmount);
            FindObjectOfType<UIDisplay>().ResetHealthSlider();
            Destroy(gameObject);
        }
    }
}
