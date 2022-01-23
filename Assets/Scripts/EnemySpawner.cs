using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<WaveConfigSO> waveConfigs;
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] bool isLooping = true;
    
    WaveConfigSO currentWave;

    void Start()
    {
        StartCoroutine(SpawnEnemyWaves());
    }

    IEnumerator SpawnEnemyWaves()
    {
        //do while loop is for infinite spawning
        do
        {
            //Wave looping logic
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                //Enemy spawning in current wave
                for (int i = 0; i < currentWave.GetEnemyCount(); i++)
                {
                    Instantiate(currentWave.GetEnemyPrefab(0),
                        currentWave.GetStartingWaypoint().position,
                        Quaternion.Euler(0, 0, 180), transform);

                    yield return new WaitForSeconds(currentWave.GetRandomSpawnTime());
                }
                yield return new WaitForSeconds(timeBetweenWaves);
            }
        } while (isLooping);
    }

    public WaveConfigSO GetCurrentWave()
    {
        return currentWave;
    }
}
