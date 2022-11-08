using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dash", menuName = "PlayerAbility/Dash")]
public class Dash : Player_BaseAbility
{
    //created by Alex

    [SerializeField] int dashDistance = 10;
    [SerializeField] int defenseIncrease = 5;

    bool dashing;

    public override void Awake()
    {
        dashing = false;
    }

    public override void Activate(GameObject parent)
    {
        //activate ability
        if(!dashing)
        {
            dashing = true;
        }
    }

    public override IEnumerator AbilityEffect(Player_BaseAbility skill, GameObject parent)
    {
        if(skill.state == AbilityState.active)
        {
            if(dashing)
            {
                Player_StatusManager.Instance.playerBaseStats.Defence += defenseIncrease;
                PlayerController.Instance.playerVelocity = dashDistance * parent.transform.forward;
                Debug.Log("Dashing");
            }
        }
        
        yield return new WaitForSeconds(skill.activeTime);

        if(dashing)
        {
            Debug.Log("StoDashing");
            Player_StatusManager.Instance.playerBaseStats.Defence -= defenseIncrease;
            PlayerController.Instance.playerVelocity = Vector3.zero;
            dashing = false;
        }
    }
}
