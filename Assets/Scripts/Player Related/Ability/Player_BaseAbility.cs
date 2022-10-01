using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BaseAbility : ScriptableObject
{
    //created by Alex

    public new string name;
    public int attack;
    public string description;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate(GameObject parent)
    {

    }
}
