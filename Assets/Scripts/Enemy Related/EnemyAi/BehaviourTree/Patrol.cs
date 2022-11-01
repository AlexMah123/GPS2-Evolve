using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
public class Patrol : Node
{
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;
    private Animator _animator;

    [Header("Ind Var")]
    private float patrolRad = 25f;
    private bool stopped = false;
    private float stoppedTime = 0;
    private float stoppedMax = 8; 

    public Patrol(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Animator animator)
    {
        _player = player;
        _transform = transform;
        _nva = nva;
        _ess = ess;
        _animator = animator;
    }
    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_player.transform.position, _transform.position);
        Vector3 targetDir = (_player.transform.position - _transform.position).normalized;
        if (d > 10)
        {
            Vector3 nextPos = Vector3.zero;
            if(stopped == false)
            {
                _animator.SetInteger("State", 1);
                patrolRad = Random.Range(25, 50);
                if (_nva.remainingDistance <= _nva.stoppingDistance)
                {
                    nextPos = PatrolPoint(patrolRad);
                    _nva.speed = _ess.Speed;
                    _nva.SetDestination(nextPos);
                }
            }
            else
            {
                if (stoppedTime <= 0)
                {
                    stopped = false;
                    _animator.SetInteger("State", 0);
                }
                else
                {
                    stoppedTime -= Time.deltaTime;
                }
            }

            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        return state;
    }
    
    public Vector3 PatrolPoint(float distance)
    {
        Vector3 dir = Random.insideUnitSphere * distance;
        dir += _transform.position;
        NavMesh.SamplePosition(dir, out NavMeshHit navHit, distance, NavMesh.AllAreas);
        stopped = true;
        stoppedTime = stoppedMax;
        return navHit.position;
    }
}
