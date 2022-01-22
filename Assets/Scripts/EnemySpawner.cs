using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] WaveConfigSO currentWave;

    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(0), 
                currentWave.GetStartingWaypoint().position, 
                Quaternion.identity, transform);
        }
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
