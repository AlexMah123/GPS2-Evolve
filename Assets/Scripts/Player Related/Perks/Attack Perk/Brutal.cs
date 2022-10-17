using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Brutal", menuName = "PlayerPerks/Attack/Brutal")]
public class Brutal: Player_BasePerk
{
    //created by Alex
    [Header("Brutal - Perk Details")]
    [SerializeField] int attackModifier = 5;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        perkMod.attackModifier += attackModifier;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        
    }
}
