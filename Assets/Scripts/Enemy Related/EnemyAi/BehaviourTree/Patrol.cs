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
    private float stoppedMax = 4;
    private float timeout = 30;
    private float timeoutMax = 30;

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
        if (d > 10 || Player_StatusManager.Instance.playerStats.CurrHealth <= 0)
        {
            Vector3 nextPos = Vector3.zero;
            if(stopped == false)
            {

                patrolRad = Random.Range(25, 50);
                if (_nva.remainingDistance <= _nva.stoppingDistance || timeout <= 0)
                {

                    nextPos = PatrolPoint(patrolRad);
                    _transform.LookAt(new Vector3(nextPos.x, _transform.position.y, nextPos.z), Vector3.up);

                    NavMeshPath path = new();

                    if(_nva.CalculatePath(nextPos, path) && path.status == NavMeshPathStatus.PathComplete)
                    {
                        _nva.SetPath(path);
                    }
                }
                else
                {
                    timeout -= Time.deltaTime;
                    _nva.speed = _ess.Speed;
                }
            }
            else
            {
                if (stoppedTime <= 0)
                {
                    stopped = false;
                    _animator.SetInteger("State", 1);
                    //Debug.Log(_animator.GetInteger("State"));
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
        stoppedMax = Random.Range(2.0f, 4.0f);
        stoppedTime = stoppedMax;
        _animator.SetInteger("State", 0);
        //Debug.Log(_animator.GetInteger("State"));
        _nva.speed = 0;
        timeout = timeoutMax;
        return navHit.position;
    }
}
