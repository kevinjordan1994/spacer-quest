using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetScrolling : MonoBehaviour
{
    [SerializeField] float scrollSpeed;

    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - scrollSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        transform.position = new Vector2(Random.Range(-3, 3), transform.position.y + Random.Range(35, 45));
    }
}
