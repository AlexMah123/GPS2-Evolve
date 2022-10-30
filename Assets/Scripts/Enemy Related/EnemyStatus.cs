using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane, edited by Alex
public class EnemyStatus : MonoBehaviour
{
    public EnemyScriptable ess;
    public float tempHealth;
    bool killed;
    bool delay;

    private void Awake()
    {
        tempHealth = ess.Health;
        killed = false;
        delay = false;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player Hitbox"))
        {
            if (PlayerController.Instance.attacking == true)
            {
                StartCoroutine(TakeDamage());
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
            Instantiate(ess.enemyDeathBody, transform.position, ess.enemyDeathBody.transform.rotation);
        }
    }

    IEnumerator TakeDamage()
    {
        if(!delay)
        {
            if (tempHealth < ess.Health * Player_StatusManager.Instance.playerStats.ExecuteValue && Player_StatusManager.Instance.playerStats.Execute)
            {
                tempHealth = 0;
                Debug.Log("Execute");
            }
            else
            {
                tempHealth -= Player_StatusManager.Instance.playerStats.Attack;
            }
            delay = true;
        }
        yield return new WaitForSeconds(1f);
        delay = false;
    }
}
