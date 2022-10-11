using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    //Ter

    public static EnemyObjectPool enemyObjectPoolInstance;
    public List<GameObject> pooledEnemies;
    public GameObject[] enemyType;
    public GameObject enemyToPool;
    public int amountToPool;
    
    void Awake()
    {
        if (enemyObjectPoolInstance == null)
        {
            enemyObjectPoolInstance = this;
        }
        else
        {
            Destroy(this);
        }

    }

    void Start()
    {
        pooledEnemies = new List<GameObject>();
        GameObject tmp;
        for (int i = 0; i < amountToPool; i++)
        {
            tmp = Instantiate(enemyToPool);
            tmp.SetActive(false);
            pooledEnemies.Add(tmp);
        }
    }

    public GameObject GetPooledEnemy()
    {
        bool hasSpawned = false;
        
        //spawned name has name(Clone)
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
                hasSpawned = true;
            }
        }

        if (!hasSpawned)
        {
            GameObject tmp = Instantiate(enemyToPool);
            pooledEnemies.Add(tmp);
            amountToPool++;
            return tmp;
        }

        return null;
    }
}
