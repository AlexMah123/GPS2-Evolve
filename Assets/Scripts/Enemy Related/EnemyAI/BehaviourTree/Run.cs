using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
public class Run : Node
{
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;
    private Animator _animator;

    [Header("Ind Var")]
    private bool Running;
    public Run(Transform transform , GameObject player,NavMeshAgent nva, EnemyScriptable ess, Animator animator)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _animator = animator;
    }
    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_player.transform.position, _transform.position);
        if (!Running && d < 15)
        {
            Running = true;
        }
        else if (Running && d > 30)
        {
            Running = false;
        }
        Vector3 targetDir = (_transform.position - _player.transform.position).normalized;
        if (Running)
        {
            _nva.speed = _ess.Speed * 2;
            _nva.SetDestination(targetDir + _transform.position);
            _animator.SetInteger("State", 2);
            //Debug.Log("Running");
            state = NodeState.RUNNING;
        }
        else 
        {
            state = NodeState.FAILURE;
        }
        
        return state;
    }
}
