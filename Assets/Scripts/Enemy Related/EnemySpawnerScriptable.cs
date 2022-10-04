using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by terrence

[CreateAssetMenu(fileName = "EnemyWave", menuName = "EnemySpawn")]

public class EnemySpawnerScriptable : ScriptableObject
{
    public GameObject enemy;
    public int spawnCount = 5;
    public float spawnDelay = 0.5f;

    [SerializeField] string testResponse = "signal received, should spawn enemy now";

    public void signalTest()
    {
        Debug.Log(testResponse);
    }
}
