using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BasePerk", menuName = "Player/BasePerkSO")]
public class Player_BasePerk : ScriptableObject
{
    //created by Alex

    [Header("Perks Description")]
    public new string name;
    public string description;
    public int healthModifier;
    public int defenceModifier;
    public int attackModifier;
    public float attackSpeedModifier;
    public float speedModifier;
    public float jumpHeightModifier;
    public float evolveBarModifier;
    public float eatHealModifier;
    public float eatTimeModifier;

    //reworking on how to apply

    public enum PerkTypes
    { 
        Attack = 0,
        HealthDefense = 1,
        MobilityUtility = 2
    }

    public PerkTypes perkTypes;

    public virtual void ApplyPerks()
    {

    }

}
