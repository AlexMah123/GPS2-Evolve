using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//created by alex
public class EnemyDevour : MonoBehaviour
{
    [SerializeField] EnemyScriptable ess;
    private Rigidbody rb
    {
        get => GetComponent<Rigidbody>();
    }

    private void Awake()
    {
        StartCoroutine(OnTheFloor());
    }

    public IEnumerator OnTheFloor()
    {
        rb.constraints = rb.velocity.y <= 0.1f ? RigidbodyConstraints.FreezePosition :
        if (rb.velocity.y <= 0.1f)
        {
            rb.constraints = 
        }
        yield break;
    }
    public IEnumerator Devouring(GameObject gameObj)
    {
        if(PlayerController.Instance.devouring)
        {
            //sets the devour time based on the players eat time
            float devouringTime = Player_StatusManager.Instance.playerStats.EatTime;

            yield return new WaitForSeconds(devouringTime);

            //adds to evolvebar based on ess + eat heal, removes from the list, and destroys the obj
            Player_StatusManager.Instance.playerStats.CurrEvolveBar += ess.EvolvePointGain + Player_StatusManager.Instance.playerStats.EvolveBarIncrease;            
            Player_StatusManager.Instance.playerStats.CurrHealth += Player_StatusManager.Instance.playerStats.EatHeal;
            PlayerController.Instance.deathbodyList.Remove(gameObj);
            Destroy(gameObj);
        }
    }

}
