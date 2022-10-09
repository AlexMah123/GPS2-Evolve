using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FocusMind", menuName = "PlayerPerks/MobilityUtility/FocusMind")]
public class FocusMind : Player_BasePerk
{
    //created by Alex
    [Header("FocusMind - Perk Details")]
    [SerializeField] int statusModifier = 5;


    public override PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        perkMod.attackModifier += statusModifier;
        return perkMod;
    }

    public override void ApplyEffects()
    {

    }
}
