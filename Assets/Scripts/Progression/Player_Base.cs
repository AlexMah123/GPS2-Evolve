using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Player_Base
{
    [SerializeField] int health = 300;
    [SerializeField] int defence = 6;
    [SerializeField] int attack = 20;
    [SerializeField] float speed = 5;
    [SerializeField] float jumpForce = 3;

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
    public float Speed
    {
        get => speed;
        set => speed = value;
    }

    public float JumpForce
    {
        get => jumpForce;
        set => jumpForce = value;
    }
    #endregion
}
