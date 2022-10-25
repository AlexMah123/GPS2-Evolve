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
    [SerializeField] int overHeal = 60;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.eatHealModifier += eatingHeal;
        perkMod.speedModifier += speedModifier;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        if(!playerObj.OverHeal)
        {
            playerObj.OverHeal = true;
            playerObj.OverHealValue = 60;
        }
    }
}
