using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Titan", menuName = "PlayerPerks/HealthDefense/Titan")]
public class Titan : Player_BasePerk
{
    //created by Alex
    [Header("Titan - Perk Details")]
    [SerializeField] int maxHealth = 100;
    [SerializeField] float sizeMod = 0.2f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.healthModifier += maxHealth;
        perkMod.sizeModifier += sizeMod;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {
        
    }
}
