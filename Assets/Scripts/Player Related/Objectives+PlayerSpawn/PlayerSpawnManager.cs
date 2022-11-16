using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//created by alex
public class PlayerSpawnManager : MonoBehaviour
{
    public static PlayerSpawnManager Instance;

    [NonReorderable] public List<GameObject> playerSpawnPoints = new();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        Debug.Log("Spawning");
        InitSpawnPlayer();
    }

    void Update()
    {
        
    }


    void InitSpawnPlayer()
    {
        int spawnIndex = 0;

        spawnIndex = Player_PerksManager._random.Next(0, playerSpawnPoints.Count);
        PlayerController.Instance.gameObject.transform.position = playerSpawnPoints[spawnIndex].transform.position;
    }
}
