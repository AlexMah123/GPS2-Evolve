using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bloodlust", menuName = "PlayerPerks/Attack/Bloodlust")]
public class Bloodlust : Player_BasePerk
{
    //created by Alex
    [Header("Bloodlust - Perk Details")]
    [SerializeField] float attackSpeed = 0.12f;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        // do something
        perkMod.attackSpeedModifier += attackSpeed;
        return perkMod;
    }

    public override void ApplyEffects()
    {
        base.ApplyEffects();
    }
}
