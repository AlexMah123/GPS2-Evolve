using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Anger", menuName = "PlayerPerks/Attack/Anger")]
public class Anger : Player_BasePerk
{
    //created by Alex
    [Header("Anger - Perk Details")]
    [SerializeField] float angerValue = 0.2f;
    [SerializeField] float duration = 3f;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        /*perkMod.speedModifier += speedModifier;
        perkMod.attackSpeedModifier += attackSpeedModifier;*/
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        if(playerObj.Anger)
        {
            if ((playerObj.AngerDuration -= Time.deltaTime) <= 0)
            {
                //if duration is inactive, reset attack speed and speed
                playerObj.AttackSpeed = Player_StatusManager.Instance.playerBaseStats.AttackSpeed + Player_StatusManager.Instance.playerPerks.attackSpeedModifier;
                playerObj.Speed = Player_StatusManager.Instance.playerBaseStats.Speed + Player_StatusManager.Instance.playerPerks.speedModifier;
                playerObj.AngerDuration = duration;
                playerObj.Anger = false;
                Debug.Log("inactive");

            }
            else
            {
                //if duration active, add the effect
                playerObj.AttackSpeed
                    = Player_StatusManager.Instance.playerBaseStats.AttackSpeed + Player_StatusManager.Instance.playerPerks.attackSpeedModifier + angerValue;

                playerObj.Speed
                    = Player_StatusManager.Instance.playerBaseStats.Speed + Player_StatusManager.Instance.playerPerks.speedModifier + angerValue;

                Debug.Log("Active");
            }
        }
    }
}
