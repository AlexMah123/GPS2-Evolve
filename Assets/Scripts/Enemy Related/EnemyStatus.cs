using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane
public class EnemyStatus : MonoBehaviour
{
    public EnemyScriptable ess;
    float tempHealth;

    private void Awake()
    {
        tempHealth = ess.Health;
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerController.Instance.attacking == true)
            {
                tempHealth -= Player_StatusManager.Instance.playerBaseStats.Attack;
                Debug.Log("Collided");
            }
            
        }
    }

    private void Update()
    {
        if (tempHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
