using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//created by alex
public class EnemyDevour : MonoBehaviour
{
    [SerializeField] EnemyScriptable ess;

    public IEnumerator Devouring(GameObject gameObj)
    {
        if(PlayerController.Instance.devouring)
        {
            //sets the devour time based on the players eat time
            float devouringTime = Player_StatusManager.Instance.playerStats.EatTime;

            yield return new WaitForSeconds(devouringTime);

            //adds to evolvebar based on ess, removes from the list, and destroys the obj
            Player_StatusManager.Instance.playerStats.CurrEvolveBar += ess.EvolvePointGain;
            PlayerController.Instance.deathbodyList.Remove(gameObj);
            Destroy(gameObj);
        }
    }

}
