using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicEnemy : MonoBehaviour
{
    //created by Terrance, edited by Alex

    public Enemy_Base enemyScriptable;
    public Enemy_Base enemyScriptable2;


    private void Start()
    {
        //enemyScriptable.Spawn();
        Debug.Log(enemyScriptable.name);
        Debug.Log(enemyScriptable2.name);

    }
}
