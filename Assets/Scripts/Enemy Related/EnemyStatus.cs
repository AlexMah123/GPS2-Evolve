using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane, edited by Alex
public class EnemyStatus : MonoBehaviour
{
    public EnemyScriptable ess;
    public GameObject deathObject;
    float tempHealth;
    bool killed;

    private void Awake()
    {
        tempHealth = ess.Health;
        killed = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player Hitbox"))
        {
            if (PlayerController.Instance.attacking == true)
            {
                if(tempHealth < ess.Health * Player_StatusManager.Instance.playerStats.ExecuteValue && Player_StatusManager.Instance.playerStats.Execute)
                {
                    tempHealth = 0;
                    Debug.Log("Execute");
                }
                else
                {
                    tempHealth -= Player_StatusManager.Instance.playerStats.Attack;
                }
                //Debug.Log("Collided");
            }
            
        }
    }

    private void Update()
    {
        if (tempHealth <= 0)
        {
            //if selected perks contains bloodlust
            if(Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[1]))
            {
                Player_StatusManager.Instance.playerStats.Bloodlust = true;
                Player_StatusManager.Instance.playerStats.BloodlustDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                Player_StatusManager.Instance.playerStats.BloodlustCap++;
            }

            killed = true;
            gameObject.SetActive(false);
        }      
    }

    private void OnDisable()
    {
        if(killed)
        {
            Instantiate(deathObject, transform.position, deathObject.transform.rotation);
        }
    }

}
