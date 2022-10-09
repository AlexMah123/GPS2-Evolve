using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DevelopedLeg", menuName = "PlayerPerks/MobilityUtility/DevelopedLeg")]
public class DevelopedLeg : Player_BasePerk
{
    //created by Alex
    [Header("DevelopedLeg - Perk Details")]
    [SerializeField] int jumpHeight = 1;
    [SerializeField] float speed = 0.2f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.jumpHeightModifier += jumpHeight;
        perkMod.speedModifier += speed;
        return perkMod;
    }

    public override void ApplyEffects()
    {

    }
}
