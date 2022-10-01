using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Enemy_Base : ScriptableObject
{
    //created by Terrance, edited by Alex

    public new string name;
    public float health;
    public float defence;
    public float speed;
    public float evolvePointGain;

    public virtual void Spawn()
    {
        //spawn
    }
}
