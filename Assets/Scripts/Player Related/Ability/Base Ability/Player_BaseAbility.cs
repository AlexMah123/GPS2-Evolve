using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player_BaseAbility : ScriptableObject
{
    //created by Alex

    [Header("Base Ability Details")]
    public Sprite logo;
    public new string name;
    public string description;
    public int attack;
    public float cooldownTime;
    public float activeTime;

    public enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    public AbilityState state = AbilityState.ready;

    public virtual void Activate(GameObject parent)
    {

    }
}
