using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemy : MonoBehaviour
{
    public Enemy_Base enemyScriptable;

    private void Start()
    {
        //enemyScriptable.Spawn();
        Debug.Log(enemyScriptable.name);
    }

}
