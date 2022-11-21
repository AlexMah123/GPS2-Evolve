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
    private float ChargeDurationMax = 2;
    private bool TargetLocked = false;
    private Vector3 targetDir = Vector3.zero;
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
        else if (d <= 15) 
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
                    _nva.speed = _ess.Speed * 4;
                    targetDir = (_player.transform.position - _transform.position).normalized;
                    Charged = true;
                    ChargeTime = 0;
                }
                else
                {
                    //charge up
                    ChargeTime += Time.deltaTime;
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
