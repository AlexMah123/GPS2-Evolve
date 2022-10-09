using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "IronScale", menuName = "PlayerPerks/HealthDefense/IronScale")]
public class IronScale : Player_BasePerk
{
    //created by Alex
    [Header("IronScale - Perk Details")]
    [SerializeField] int defenseModifier = 6;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.defenceModifier += defenseModifier;
        return perkMod;
    }

    public override void ApplyEffects()
    {

    }
}
