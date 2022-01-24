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
}
