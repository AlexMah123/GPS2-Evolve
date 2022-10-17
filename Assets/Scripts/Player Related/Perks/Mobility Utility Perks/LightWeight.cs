using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LightWeight", menuName = "PlayerPerks/MobilityUtility/LightWeight")]
public class LightWeight : Player_BasePerk
{
    //created by Alex
    [Header("LightWeight - Perk Details")]
    [SerializeField] float speed = 0.8f;
    [SerializeField] int maxHealth = -40;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.speedModifier += speed;
        perkMod.healthModifier += maxHealth;
        return perkMod;
    }

    public override void ApplyEffects(Player_Base playerObj)
    {

    }
}
