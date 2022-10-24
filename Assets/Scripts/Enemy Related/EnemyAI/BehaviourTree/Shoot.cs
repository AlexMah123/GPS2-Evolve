using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : Node
{
    //ter
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;
    private Player_Base _pb;

    [Header("Ind Var")]
    private bool Shooting;
    private float Reloading;

    public Shoot(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Player_Base pb)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _pb = pb;
    }

    public override NodeState Evaluate()
    {

        float d = Vector3.Distance(_transform.position, _player.transform.position);

        if (Shooting)
        {
            if (d > 20)//shooting max range
            {
                Shooting = false;
            }
        }
        else if (d < 15)//start shooting range
        {
            Shooting = true;
        }

        Vector3 targetDir = (_player.transform.position - _transform.position).normalized;

        if (Shooting)
        {
            //_nva.speed = 0;
            //_nva.SetDestination(targetDir + _transform.position);
            if (Reloading >= 10 / _ess.AttackSpeed)
            {
                RaycastHit Hit;
                if (Physics.Raycast(_transform.position, targetDir, out Hit, 20))
                {
                    Debug.DrawRay(_transform.position, targetDir * 20);
                    if (Hit.transform.gameObject == _player)
                    {
                        Debug.Log("Player has been hit!");
                        _pb
                    }
                }
            }
            else
            {
                Reloading += Time.deltaTime;
            }
            state = NodeState.RUNNING;
        }
        else
        {
            state = NodeState.FAILURE;
        }
        return state;
    }
}
