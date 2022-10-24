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
    private Player_StatusManager _psm;

    [Header("Ind Var")]
    private bool Shooting;
    private float Reloading;

    public Shoot(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Player_StatusManager psm)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _psm = psm;
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
        targetDir.y += 0.25f;

        if (Shooting)
        {
            Debug.DrawRay(_transform.position, targetDir * 20);
            if (Reloading >= 1 / _ess.AttackSpeed)
            {
                //Shoot!
                RaycastHit Hit;
                int dmg;
                if (Physics.Raycast(_transform.position, targetDir, out Hit, 20))
                {
                    if (Hit.transform.gameObject == _player)
                    {
                        dmg = _ess.Attack - _psm.playerStats.Defence;
                        if (dmg < 0)
                        {
                            dmg = 0;
                        }
                        Debug.Log("Player has been hit!");
                        _psm.playerStats.CurrHealth -= dmg;
                    }
                    else
                    {
                        Debug.Log("Hit something else");
                    }
                    Reloading = 0;
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
