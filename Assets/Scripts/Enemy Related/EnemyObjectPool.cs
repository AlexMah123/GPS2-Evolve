using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour
{
    //Ter

    public static EnemyObjectPool enemyObjectPoolInstance;
    public List<GameObject> pooledEnemies;
    public GameObject[] enemyTypes;
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

    public GameObject GetPooledEnemy(ScriptableObject enemyScriptable)
    {
        bool hasSpawned = false;
        string spawnName;

        switch (enemyScriptable.name)
        {
            case "Unarmed Enemy":
                spawnName = "EnemyBeta(Clone)";
                break;
            case "Armed Human":
                spawnName = "2(Clone)";
                break;
            default:
                spawnName = null;
                break;
        }

        for(int i = 0; i < amountToPool; i++)
        {
            if (!pooledEnemies[i].activeInHierarchy && pooledEnemies[i].name == spawnName)
            {
                return pooledEnemies[i];
                hasSpawned = true;
            }
        }

        if (!hasSpawned)
        {
            if(enemyScriptable.name == "Unarmed Enemy")
            {
                enemyToPool = enemyTypes[0];
            }
            else if(enemyScriptable.name == "ArmedHuman") 
            {
                enemyToPool = enemyTypes[1];
            }
            GameObject tmp = Instantiate(enemyToPool);
            pooledEnemies.Add(tmp);
            amountToPool++;
            return tmp;
        }

        return null;
    }
}
