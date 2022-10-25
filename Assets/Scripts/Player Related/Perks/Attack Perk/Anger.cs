using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Anger", menuName = "PlayerPerks/Attack/Anger")]
public class Anger : Player_BasePerk
{
    //created by Alex
    [Header("Anger - Perk Details")]
    [SerializeField] float angerValue = 0.2f;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        /*perkMod.speedModifier += speedModifier;
        perkMod.attackSpeedModifier += attackSpeedModifier;*/
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        if (!playerObj.Anger)
        {
            playerObj.Anger = true;
            playerObj.AngerValue = angerValue;
        }
    }
}
