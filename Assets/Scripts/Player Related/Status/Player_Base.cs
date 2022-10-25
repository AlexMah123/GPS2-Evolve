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


    #region Base Stats Properties
    public int CurrHealth
    {
        get => currHealth;
        set => currHealth = value;
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
        set => attackSpeed = value;
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
        set => currEvolveBar = value;
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
        set => size = value;
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
    #endregion
}
