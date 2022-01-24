using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxScrolling : MonoBehaviour
{
    [SerializeField] Vector2 scrollSpeed;
    
    Vector2 offset;
    Material material;
    
    void Awake()
    {
        material = GetComponent<SpriteRenderer>().material;
    }

    void Update()
    {
        offset = scrollSpeed * Time.deltaTime;
        material.mainTextureOffset += offset;
    }
}
