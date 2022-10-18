using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PerkTypes
{
    Attack = 0,
    HealthDefense = 1,
    MobilityUtility = 2
}

public abstract class Player_BasePerk : ScriptableObject
{
    //created by Alex

    //base attributes that all perks will inherit
    [Header("Perks Description")]
    public new string name;
    public string description;
    public PerkTypes perkTypes;


    public virtual void Awake()
    {
        //runs awake in individual perks
        //do nothing
    }

    public virtual PerkModifiers ApplyPerks(PerkModifiers perkMod)
    {
        //do nothing
        return perkMod;
    }

    public virtual void ApplyEffects(Player_Base playerObj)
    {
        //apply effects in individual perks 
        //do nothing
    }
}

[System.Serializable]
public struct PerkModifiers
{
    //struct to hold all the modifiers
    public int healthModifier;
    public int defenceModifier;
    public int attackModifier;
    public float attackSpeedModifier;
    public float speedModifier;
    public float jumpHeightModifier;
    public float evolveBarModifier;
    public int eatHealModifier;
    public float eatTimeModifier;
    public float buffExtendModifier;

    public PerkModifiers(int healthMod, int defenceMod, int attackMod, float attackSpeedMod, float speedMod, float jumpHeightMod, float evolveBarMod ,int eatHealMod, float eatTimeMod, float buffExtendMod)
    {
        healthModifier = healthMod;
        defenceModifier = defenceMod;
        attackModifier = attackMod;
        attackSpeedModifier = attackSpeedMod;
        speedModifier = speedMod;
        jumpHeightModifier = jumpHeightMod;
        evolveBarModifier = evolveBarMod;
        eatHealModifier = eatHealMod;
        eatTimeModifier = eatTimeMod;
        buffExtendModifier = buffExtendMod;
    }
}