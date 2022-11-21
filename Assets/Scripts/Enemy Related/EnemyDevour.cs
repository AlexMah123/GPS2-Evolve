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

    private void Start()
    {
        StartCoroutine(OnTheFloor());
    }

    public IEnumerator OnTheFloor()
    {
        yield return new WaitForSeconds(1);
        while (rb.velocity.y > 0.1f)
        {
            yield return null;
        }
        rb.constraints = RigidbodyConstraints.FreezeAll;
        
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
