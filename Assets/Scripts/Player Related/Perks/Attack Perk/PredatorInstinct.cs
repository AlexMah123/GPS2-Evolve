using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredatorInstinct", menuName = "PlayerPerks/Attack/PredatorInstinct")]
public class PredatorInstinct : Player_BasePerk
{
    //created by Alex
    [Header("Predator Instinct - Perk Details")]
    [SerializeField] int attackModifier = -8;
    [SerializeField] float executeValue = 0.25f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        perkMod.attackModifier += attackModifier;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        if (!playerObj.Execute)
        {
            playerObj.Execute = true;
            playerObj.ExecuteValue = executeValue;
        }
    }
}
