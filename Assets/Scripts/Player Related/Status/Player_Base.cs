using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player_Base
{
    //created by Alex
    [Header("Base stats properties")]
    [SerializeField] int currHealth = 300;
    [SerializeField] int maxHealth = 300;
    [SerializeField] int defence = 5;
    [SerializeField] int attack = 20;
    [SerializeField] float attackSpeed = 0.8f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] int currEvolveBar = 0;
    [SerializeField] int maxEvolveBar = 80;
    [SerializeField] int eatHeal = 5;
    [SerializeField] float eatTime = 1.5f;
    [SerializeField] float buffExtend = 0f;
    [SerializeField] float size = 0.8f;

    [Header("Perk properties")]
    [Tooltip("Predator Instinct Perk")]
    [SerializeField] bool execute = false;
    [SerializeField] float executeValue = 0f;

    [Tooltip("Store Fat Perk")]
    [SerializeField] bool overHeal = false;
    [SerializeField] int overHealValue = 0;

    [Tooltip("Tenacity Perk")]
    [SerializeField] bool block = false;
    [SerializeField] float blockChance = 0f;

    [Tooltip("Bloodlust Perk")]
    [SerializeField] bool bloodlust = false;
    [SerializeField] float bloodlustCap = 0f;
    [SerializeField] float bloodlustDuration = 0f;

    [Tooltip("Anger Perk")]
    [SerializeField] bool anger = false;
    [SerializeField] float angerValue = 0f;
    [SerializeField] float angerDuration = 0f;

    public void Reset()
    {
        //CurrHealth = currHealth;
        MaxHealth = maxHealth;
        Defence = defence;
        Attack = attack;
        AttackSpeed = attackSpeed;
        Speed = speed;
        JumpHeight = jumpHeight;
        CurrEvolveBar = currEvolveBar;
        MaxEvolveBar = maxEvolveBar;
        EatHeal = eatHeal;
        BuffExtend = buffExtend;
        Size = size;

        Execute = execute;
        ExecuteValue = executeValue;
        OverHeal = overHeal;
        OverHealValue = overHealValue;
        Block = block;
        BlockChance = blockChance;
        Bloodlust = bloodlust;
        BloodlustCap = bloodlustCap;
        BloodlustDuration = bloodlustDuration;
        Anger = anger;
        AngerValue = angerValue;

        Player_StatusManager.Instance.UpdatePlayerStats();
    }

    #region Base Stats Properties
    public int CurrHealth
    {
        get => currHealth;
        set => currHealth = Mathf.Clamp(value, 0, MaxHealth);
    }
     public int MaxHealth
    {
        get => maxHealth;
        set => maxHealth = value;
    }

    public int Defence
    {
        get => defence;
        set => defence = value;
    }

    public int Attack
    {
        get => attack;
        set => attack = value;
    }

    public float AttackSpeed
    {
        get => attackSpeed;
        set => attackSpeed = Mathf.Clamp(value, 0.8f, 1.5f);
    }

    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float JumpHeight
    {
        get => jumpHeight;
        set => jumpHeight = value;
    }

    public int MaxEvolveBar
    {
        get => maxEvolveBar;
        set => maxEvolveBar = value;
    }

    public int CurrEvolveBar
    {
        get => currEvolveBar;
        set => currEvolveBar = Mathf.Clamp(value, 0, MaxEvolveBar);
    }

    public int EatHeal
    {
        get => eatHeal;
        set => eatHeal = value;
    }

    public float EatTime
    {
        get => eatTime;
        set => eatTime = value;
    }

    public float BuffExtend
    {
        get => buffExtend;
        set => buffExtend = value;
    }

    public float Size
    {
        get => size;
        set => size = Mathf.Clamp(value, Size, 1.5f);
    }

    #endregion

    #region Perks Properties
    public bool Execute
    {
        get => execute;
        set => execute = value;
    }

    public float ExecuteValue
    {
        get => executeValue;
        set => executeValue = value;
    }

    public bool OverHeal
    {
        get => overHeal;
        set => overHeal = value;
    }

    public int OverHealValue
    {
        get => overHealValue;
        set => overHealValue = value;
    }

    public bool Block
    {
        get => block;
        set => block = value;
    }

    public float BlockChance
    {
        get => blockChance;
        set => blockChance = value;
    }

    public bool Bloodlust
    {
        get => bloodlust;
        set => bloodlust = value;
    }

    public float BloodlustCap
    {
        get => bloodlustCap;
        set => bloodlustCap = Mathf.Clamp(value, 0, 3f);
    }

    public float BloodlustDuration
    {
        get => bloodlustDuration;
        set => bloodlustDuration = Mathf.Clamp(value, 0, 3 + BuffExtend);
    }

    public bool Anger
    {
        get => anger;
        set => anger = value;
    }

    public float AngerValue
    {
        get => angerValue;
        set => angerValue = value;
    }

    public float AngerDuration
    {
        get => angerDuration;
        set => angerDuration = Mathf.Clamp(value, 0, 3 + BuffExtend);
    }
    #endregion

}
