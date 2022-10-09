using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Feast", menuName = "PlayerPerks/MobilityUtility/Feast")]
public class Feast : Player_BasePerk
{
    //created by Alex
    [Header("Feast - Perk Details")]
    [SerializeField] int evolvePointGain = 1;
    [SerializeField] float eatTime = 0.5f;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.evolveBarModifier += evolvePointGain;
        perkMod.eatTimeModifier += eatTime;
        return perkMod;
    }

    public override void ApplyEffects()
    {

    }
}
