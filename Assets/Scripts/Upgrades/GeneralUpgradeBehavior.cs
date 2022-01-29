using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneralUpgradeBehavior : MonoBehaviour
{
    void Start()
    {
        Destroy(gameObject, 15f);
    }

    void Update()
    {
        transform.position += Vector3.down * Time.deltaTime * 2;
    }
}
