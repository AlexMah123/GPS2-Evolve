using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
public class Walk : Node
{
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _scriptableEnemy;

    public Walk(GameObject player, Transform transform,NavMeshAgent nva)
    {
        _player = player;
        _transform = transform;
        _nva = nva;
    }
    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_player.transform.position, _transform.position);
        if (d > 10)
        {
            //Enter patrol stuff here
            Debug.Log("walking");
            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        return state;
    }
}
