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
        if (collision.gameObject.CompareTag("Player Hitbox"))
        {
            if (PlayerController.Instance.attacking == true)
            {
                if(tempHealth < tempHealth * Player_StatusManager.Instance.playerStats.ExecuteValue && Player_StatusManager.Instance.playerStats.Execute)
                {
                    tempHealth = 0;
                    Debug.Log("Execute");
                }
                else
                {
                    tempHealth -= Player_StatusManager.Instance.playerStats.Attack;
                }

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
