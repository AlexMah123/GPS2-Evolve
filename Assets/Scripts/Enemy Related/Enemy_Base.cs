using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy/Enemy_BaseSO")]
public class Enemy_Base : ScriptableObject
{
    //created by Terrance, edited by Alex

    public new string name;
    public int health;
    public int defence;
    public int attack;
    public float attackSpeed;
    public float speed;
    public float evolvePointGain;

    public virtual void Spawn()
    {
        //spawn
    }

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
    #endregion
}
