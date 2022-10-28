using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDevour : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Devour Hitbox"))
        {
            Debug.Log("Devouring");
            if(PlayerController.Instance.devouring)
            {
                Player_StatusManager.Instance.playerStats.CurrEvolveBar += 10;
                Destroy(gameObject);
            }
            
        }
    }

}
