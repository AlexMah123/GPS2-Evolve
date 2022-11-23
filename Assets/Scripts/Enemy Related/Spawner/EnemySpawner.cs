using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by terrence, editted by alex
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Related")]
    [SerializeField] EnemyScriptable[] EnemySpawnableList;

    [Header("Spawner Values")]
    [SerializeField] float currentWaveDelay = 3;
    [SerializeField] float currentSpawnDelay = 1;
    [SerializeField] int maxNumSpawned = 5;
    [SerializeField] int waveCount;

    float tempWaveDelay;
    float tempSpawnDelay = 0;
    int enemyIndex = 0;
    int numSpawned = 0;

    void Awake()
    {
        tempWaveDelay = currentWaveDelay;
        currentSpawnDelay = EnemySpawnableList[enemyIndex].spawnDelay;
    }

    void Update()
    {
        tempWaveDelay -= Time.deltaTime;

        if(tempWaveDelay <= 0 )
        {
            SpawnEnemy();
        }
    }

    void SpawnEnemy()
    {
        //reduce spawn timer
        tempSpawnDelay -= Time.deltaTime;

        //if 0 and have not spawned enemy amount, spawn and +numSpawned, reset timer for next spawn
        if(tempSpawnDelay <= 0 && numSpawned < maxNumSpawned)
        {
            GameObject enemy = EnemyObjectPool.enemyObjectPoolInstance.GetPooledEnemy(EnemySpawnableList[enemyIndex]);

            if (enemy != null)
            {
                //spawn enemy at spawnPoint within area
                enemy.transform.localPosition = new Vector3(transform.position.x + Random.Range(-3.0f, 3.0f),
                    transform.position.y, transform.position.z + Random.Range(-3.0f, 3.0f));

                enemy.transform.rotation = transform.rotation;
                enemy.SetActive(true);

            }

            //increment numSpawn, 
            numSpawned++;
            tempSpawnDelay = currentSpawnDelay;
        }
        // if numSpawned > the amount of enemy type and next index is not outside of range
        else if(numSpawned >= EnemySpawnableList[enemyIndex].spawnCount && enemyIndex + 1 < EnemySpawnableList.Length)
        {
            //increment, reset numSpawned
            enemyIndex++;
            numSpawned = 0;
            //reset delays
            currentSpawnDelay = EnemySpawnableList[enemyIndex].spawnDelay;
            tempSpawnDelay = currentSpawnDelay;

        }
    }

}
