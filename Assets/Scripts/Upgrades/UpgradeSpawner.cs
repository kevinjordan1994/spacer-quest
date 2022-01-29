using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeSpawner : MonoBehaviour
{
    [SerializeField] List<Transform> spawnPoints;
    [SerializeField] List<GameObject> upgrades;

    void Start()
    {
        StartCoroutine(SpawnUpgrade());
    }

    IEnumerator SpawnUpgrade()
    {
        while (true)
        {
            Instantiate(upgrades[Random.Range(0, upgrades.Count)], spawnPoints[Random.Range(0, spawnPoints.Count)].position, Quaternion.identity);
            yield return new WaitForSeconds(15f);
        }
    }
}
