using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bloodlust", menuName = "PlayerPerks/Attack/Bloodlust")]
public class Bloodlust : Player_BasePerk
{
    //created by Alex
    [Header("Bloodlust - Perk Details")]
    [SerializeField] float bloodlustValue = 0.12f;
    [SerializeField] float duration = 3f;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        //if bloodlust triggered
        if(playerObj.Bloodlust)
        {
            if ((playerObj.BloodlustDuration -= Time.deltaTime) <= 0)
            {
                //if duration is inactive, reset attack speed
                playerObj.AttackSpeed = Player_StatusManager.Instance.playerBaseStats.AttackSpeed + Player_StatusManager.Instance.playerPerks.attackSpeedModifier;
                playerObj.BloodlustDuration = duration;
                playerObj.BloodlustCap = 0;
                playerObj.Bloodlust = false;
            }
            else
            {
                //if duration active, add the effect
                playerObj.AttackSpeed 
                    = Player_StatusManager.Instance.playerBaseStats.AttackSpeed + Player_StatusManager.Instance.playerPerks.attackSpeedModifier + bloodlustValue * playerObj.BloodlustCap;
            }
        }
    }
}
