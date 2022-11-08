using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Roar", menuName = "PlayerAbility/Roar")]
public class Roar : Player_BaseAbility
{
    //created by Alex
    
    [SerializeField] float uptime = 5f;
    [SerializeField] int defenseIncrease = 4;
    [SerializeField] float attkSpeedIncrease = 0.2f;
    bool once;

    public override void Activate(GameObject parent)
    {
        once = false;
    }

    public override IEnumerator AbilityEffect(Player_BaseAbility skill, GameObject parent)
    {
        if (!once)
        {
            Player_StatusManager.Instance.playerBaseStats.Defence += defenseIncrease;
            Player_StatusManager.Instance.playerBaseStats.AttackSpeed += attkSpeedIncrease;
            once = true;
        }

        float newtime = uptime + Player_StatusManager.Instance.playerStats.BuffExtend;
        yield return new WaitForSeconds(newtime);
        
        if(once)
        {
            Player_StatusManager.Instance.playerBaseStats.Defence -= defenseIncrease;
            Player_StatusManager.Instance.playerBaseStats.AttackSpeed -= attkSpeedIncrease;
            once = false;
        }
    }
}
