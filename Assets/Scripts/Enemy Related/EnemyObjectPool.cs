using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    //Ter

    public static EnemyObjectPool enemyObjectPoolInstance;
    public List<GameObject> pooledEnemies;
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
        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy)
            {
                return pooledEnemies[i];
            }
        }
        return null;
    }
}
