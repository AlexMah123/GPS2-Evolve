using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Titan", menuName = "PlayerPerks/HealthDefense/Titan")]
public class Titan : Player_BasePerk
{
    //created by Alex
    [Header("Titan - Perk Details")]
    [SerializeField] int maxHealth = 100;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.healthModifier += maxHealth;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {

    }
}
