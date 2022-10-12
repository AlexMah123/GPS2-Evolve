using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player_Base
{
    //created by Alex

    [SerializeField] int health = 300;
    [SerializeField] int defence = 5;
    [SerializeField] int attack = 20;
    [SerializeField] float attackSpeed = 0.8f;
    [SerializeField] float speed = 2;
    [SerializeField] float jumpHeight = 3;
    [SerializeField] int currEvolveBar = 0;
    [SerializeField] int maxEvolveBar = 80;
    [SerializeField] int eatHeal = 5;
    [SerializeField] float eatTime = 1.5f;

    #region Properties
    public int Health
    {
        get => health;
        set => health = value;
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
    #endregion
}
