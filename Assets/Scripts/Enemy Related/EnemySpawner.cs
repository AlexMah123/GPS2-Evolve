using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by terrence
public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyScriptable[] ESS;
    [SerializeField] float waveDelayMax = 3;
    float waveDelay;
    int currentESS = 0;
    int spawned = 0;
    float spawnDelayMax = 1;
    float spawnDelay = 0;

    void Awake()
    {
        waveDelay = waveDelayMax;
        spawnDelayMax = ESS[currentESS].spawnDelay;
    }

    void Update()
    {
        waveDelay -= Time.deltaTime;
        if (waveDelay <= 0)
        {
            spawnDelay -= Time.deltaTime;
            if (spawnDelay <= 0 && spawned < ESS[currentESS].spawnCount)
            {
                //Instantiate(ESS[currentESS].enemy, transform.position, Quaternion.identity);
                
                GameObject enemy = EnemyObjectPool.enemyObjectPoolInstance.GetPooledEnemy();

                if (enemy != null)
                {
                    enemy.transform.position = new Vector3(transform.position.x + Random.Range(-2.0f, 2.0f), transform.position.y, transform.position.z + Random.Range(-2.0f, 2.0f));
                    enemy.transform.rotation = transform.rotation;
                    enemy.SetActive(true);
                    ESS[currentESS].signalTest();
                }

                spawned++;
                spawnDelay = spawnDelayMax;

                //ESS[currentESS].signalTest();
            }
            else if (spawned >= ESS[currentESS].spawnCount && currentESS+1 < ESS.Length)
            {
                currentESS++;
                spawned = 0;
                spawnDelayMax = ESS[currentESS].spawnDelay;
                waveDelay = waveDelayMax;
            }
        }
    }
}
