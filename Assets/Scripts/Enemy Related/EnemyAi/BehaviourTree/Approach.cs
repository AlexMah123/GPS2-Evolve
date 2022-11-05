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
    private Animator _animator;

    [Header("Ind Var")]
    private bool Approaching;

    public Approach(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Animator animator)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _animator = animator;
    }
    public override NodeState Evaluate()
    {
        //Debug.Log(Approaching);
        float d = Vector3.Distance(_transform.position, _player.transform.position);

        if(d < 15)
        {
            Approaching = false;
        }
        else if(d < 45 && !Approaching)
        {
            Approaching = true;
        }
        else if (d > 100 && Approaching)
        {
            Approaching = false;
        }

        Vector3 separateDir = Vector3.zero;

        //avoid by Ter

        /*Debug.DrawRay(_transform.position, _transform.right * 5, Color.cyan);
        Debug.DrawRay(_transform.position, -_transform.right * 5, Color.cyan);
        Debug.DrawRay(_transform.position, (_transform.right + _transform.forward) * 5, Color.cyan);
        Debug.DrawRay(_transform.position, (_transform.right - _transform.forward) * 5, Color.cyan);
        Debug.DrawRay(_transform.position, (-_transform.right + _transform.forward) * 5, Color.cyan);
        Debug.DrawRay(_transform.position, (-_transform.right - _transform.forward) * 5, Color.cyan);*/

        if (Physics.Raycast(_transform.position, _transform.right, 5) || Physics.Raycast(_transform.position, (_transform.right + _transform.forward).normalized, 5) || Physics.Raycast(_transform.position, (_transform.right - _transform.forward).normalized, 5))
        {
            separateDir -= _transform.right;
        }

        if (Physics.Raycast(_transform.position, -_transform.right, 5) || Physics.Raycast(_transform.position, (-_transform.right + _transform.forward).normalized, 5) || Physics.Raycast(_transform.position, (-_transform.right - _transform.forward).normalized, 5))
        {
            separateDir += _transform.right;
        }
        separateDir = separateDir.normalized * 0.5f;

        Vector3 targetDir = (_player.transform.position - _transform.position).normalized;
        if(Approaching)
        {
            _nva.speed = _ess.Speed * 2;
            _nva.SetDestination(targetDir + _transform.position + separateDir);
            _transform.LookAt(_player.transform);
            _animator.SetInteger("State", 2);
            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        return state;
    }
}
