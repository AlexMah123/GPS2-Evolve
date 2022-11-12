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
    private bool DamageActive = false;
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
        Vector3 targetDir = Vector3.zero;
        float d = Vector3.Distance(_player.transform.position, _transform.position);
        if (!Detected && d < 15)
        {
            Detected = true;
            _animator.SetInteger("State", 2);
            _animator.SetFloat("Blend", _animator.GetFloat("Blend") + Time.deltaTime);
        }
        else if (Detected && d > 25)
        {
            Detected = false;
        }
        

        if (Detected)
        {
            if (!Charged)
            {
                targetDir = (_player.transform.position - _transform.position).normalized; //to be changed to predict
                if (ChargeTime < ChargeTimeMax)
                {
                    ChargeTime += Time.deltaTime;
                }
                else
                {
                    Charged = true;
                    DamageActive = true;
                }
            }
            else
            {
                //charge at player
                if (ChargeDuration < ChargeDurationMax)
                {
                    ChargeDuration += Time.deltaTime;
                    _nva.speed = _ess.Speed * 4;
                    _nva.SetDestination(targetDir + _transform.position);
                }
                else
                {
                    Charged = false;
                    DamageActive = false;
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
}
