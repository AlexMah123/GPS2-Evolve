using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Terrence, original by HYZ
public class Charge : Node
{
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;
    private Animator _animator;
    private Player_StatusManager _psm;

    [Header("Ind Var")]
    private bool Charged;
    private bool Detected;
    private float ChargeTime = 0;
    private float ChargeTimeMax = 3.5f;
    private float ChargeDuration = 0;
    private float ChargeDurationMax = 3;
    private Vector3 targetDir = Vector3.zero;
    private Vector3 targetMoveDir, targetPrevPos = Vector3.zero;
    private float dot;
    public Charge(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Animator animator, Player_StatusManager psm)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _animator = animator;
        _psm = psm;
    }

    public override NodeState Evaluate()
    {
        float d = Vector3.Distance(_player.transform.position, _transform.position);
        
        //distance check
        if (Detected && d > 15)
        {
            Detected = false;
        }
        else if (d <= 25) 
        {
            Detected = true;
        }

        if (Detected)
        {
            if (Charged)
            {
                //attack and cooldown
                _nva.SetDestination(targetDir + _transform.position);
                if (d <= 0.15f || ChargeDuration >= ChargeDurationMax)
                {
                    ChargeDuration = 0;
                    Charged = false;
                    Debug.Log("Stop Attacking");
                }
                else
                {
                    //attacking
                    ChargeDuration += Time.deltaTime;
                }
            }
            else
            {
                //ramp up
                if (ChargeTime >= ChargeTimeMax)
                {
                    //release
                    targetMoveDir = (_player.transform.position - targetPrevPos).normalized;
                    dot = Vector3.Dot((_player.transform.position - _transform.position).normalized, targetMoveDir);
                    //charging speed is 7.2
                    _nva.speed = _ess.Speed * 6;
                    if (dot >= -0.9239f) 
                    {
                        targetDir = (_player.transform.position - _transform.position).normalized + (targetMoveDir * d / 2);
                        //amount to multiply d by is a guess
                    }
                    else
                    {
                        targetDir = (_player.transform.position - _transform.position).normalized;
                    }
                    _transform.LookAt(new Vector3(targetDir.x, _transform.position.y, targetDir.z), Vector3.up);
                    Charged = true;
                    ChargeTime = 0;
                    Debug.Log("Start Attacking" + targetDir);
                }
                else
                {
                    //charge up
                    _nva.SetDestination(_transform.position);
                    ChargeTime += Time.deltaTime;
                    _transform.LookAt(new Vector3(_player.transform.position.x, _transform.position.y, _player.transform.position.z), Vector3.up);
                    targetPrevPos = _player.transform.position;
                    //Debug.Log("Charging up: " + ChargeTime);
                }
            }
        }

        //Relay back to tree
        if (Detected)
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
