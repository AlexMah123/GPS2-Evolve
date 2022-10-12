using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane
public class EnemyStatus : MonoBehaviour
{
    public EnemyScriptable ess;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerController.Instance.attacking == true)
            {
                ess.Health -= Player_StatusManager.Instance.playerBaseStats.Attack;
                Debug.Log("Collided");
            }
            
        }
    }

    private void Update()
    {
        if (ess.Health <= 0)
        {
            gameObject.SetActive(false);
        }
    }
}
