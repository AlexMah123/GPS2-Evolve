using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Approach : Node
{
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;

    [Header("Ind Var")]
    private bool Approaching;

    public Approach(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
    }
    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_transform.position, _player.transform.position);

        if(d < 45 && !Approaching)
        {
            Approaching = true;
        }
        else if (d > 100 && Approaching)
        {
            Approaching = false;
        }
        Vector3 targetDir = (_player.transform.position - _transform.position).normalized;
        if(Approaching)
        {
            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        return state;
    }
}
