using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StoreFat", menuName = "PlayerPerks/HealthDefense/StoreFat")]
public class StoreFat : Player_BasePerk
{
    //created by Alex
    [Header("Store Fat - Perk Details")]
    [SerializeField] int eatingHeal = 5;
    [SerializeField] float speedModifier = -0.2f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.eatHealModifier += eatingHeal;
        perkMod.speedModifier += speedModifier;
        return perkMod;
    }

    public override void ApplyEffects()
    {

    }
}
