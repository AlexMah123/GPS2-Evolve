using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Brutal", menuName = "Player/Perks/Brutal")]
public class Brutal: Player_BasePerk
{
    //created by Alex
    [Header("Brutal - Perk Details")]
    public int attackModifier = 7;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        perkMod.attackModifier += attackModifier;
        return perkMod;
    }
}
