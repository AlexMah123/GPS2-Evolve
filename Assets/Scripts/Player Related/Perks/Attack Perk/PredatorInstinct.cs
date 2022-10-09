using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PredatorInstinct", menuName = "PlayerPerks/Attack/PredatorInstinct")]
public class PredatorInstinct : Player_BasePerk
{
    //created by Alex
    [Header("Predator Instinct - Perk Details")]
    [SerializeField] int attackModifier = -8;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        perkMod.attackModifier += attackModifier;
        return perkMod;
    }

    public override void ApplyEffects()
    {
        base.ApplyEffects();
    }
}
