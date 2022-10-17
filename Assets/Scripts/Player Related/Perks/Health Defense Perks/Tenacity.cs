using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tenacity", menuName = "PlayerPerks/HealthDefense/Tenacity")]

public class Tenacity : Player_BasePerk
{
    //created by Alex
    [Header("Tenacity - Perk Details")]
    [SerializeField] float statusModifier = 0.15f;

    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
       
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {

    }
}
