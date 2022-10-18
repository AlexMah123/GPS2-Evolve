using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enduring", menuName = "PlayerPerks/MobilityUtility/Enduring")]
public class Enduring : Player_BasePerk
{
    //created by Alex
    [Header("Enduring - Perk Details")]
    [SerializeField] float buffModifier = 3f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.buffExtendModifier += buffModifier;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        
    }
}
