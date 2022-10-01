using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : ScriptableObject
{
    //created by terrence

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
