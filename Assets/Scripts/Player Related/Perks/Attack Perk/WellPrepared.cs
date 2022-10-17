using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WellPrepared", menuName = "PlayerPerks/Attack/WellPrepared")]
public class WellPrepared : Player_BasePerk
{
    //created by Alex
    [Header("Well Prepared - Perk Details")]
    [SerializeField] int attackModifier = 7;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // if player health >= 75%, apply attack
        /*if()
        {
            perkMod.attackModifier += attackModifier;
        }
        else
        {
            perkMod.attackModifier += 0;
        }*/

        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {

        
    }
}
