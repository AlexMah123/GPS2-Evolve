using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : Node
{
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    public Run(Transform transform , GameObject player,NavMeshAgent nva)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
    }
    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_player.transform.position, _transform.position);

        if(d < 30)
        {
            Debug.Log("Running");
            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        
        return state;
    }
}
