using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by terrence, editted by alex
public class EnemySpawner : MonoBehaviour
{
    [Header("Enemy Spawner Related")]
    [SerializeField] EnemyScriptable[] EnemySpawnableList;
    [SerializeField] GameObject spawnPoint;

    [Header("Spawner Values")]
    [SerializeField] float currentWaveDelay = 3;
    [SerializeField] float currentSpawnDelay = 1;

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
        SpawnEnemy();
    }

    void SpawnEnemy()
    {
        //reduce spawn timer
        tempSpawnDelay -= Time.deltaTime;

        //if 0 and have not spawned enemy amount, spawn and +numSpawned, reset timer for next spawn
        if(tempSpawnDelay <= 0 && numSpawned < EnemySpawnableList[enemyIndex].spawnCount)
        {
            GameObject enemy = EnemyObjectPool.enemyObjectPoolInstance.GetPooledEnemy(EnemySpawnableList[enemyIndex]);

            if (enemy != null)
            {
                //spawn enemy at spawnPoint within area
                enemy.transform.position = new Vector3(spawnPoint.transform.position.x + Random.Range(-2.0f, 2.0f),
                    spawnPoint.transform.position.y, spawnPoint.transform.position.z + Random.Range(-2.0f, 2.0f));

                enemy.transform.rotation = spawnPoint.transform.rotation;
                enemy.SetActive(true);
                Debug.Log(enemy.transform.position);
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
