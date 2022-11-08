using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Shoot : Node
{
    //ter, editted by Alex
    [Header("Tree Var")]
    private GameObject _player;
    private Transform _transform;
    private NavMeshAgent _nva;
    private EnemyScriptable _ess;
    private Player_StatusManager _psm;
    private Animator _animator;

    [Header("Ind Var")]
    private bool Shooting;
    private float Reloading;

    public Shoot(Transform transform, GameObject player, NavMeshAgent nva, EnemyScriptable ess, Player_StatusManager psm, Animator animator)
    {
        _transform = transform;
        _player = player;
        _nva = nva;
        _ess = ess;
        _psm = psm;
        _animator = animator;
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
            _animator.SetInteger("State", 3);
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

                        //if block is active, run the effect
                        if(_psm.playerStats.Block)
                        {
                            int rand = Random.Range(0, 100);

                            //if the chance of block is hit
                            if (rand < _psm.playerStats.BlockChance * 100)
                            {
                                Debug.Log("Blocked!");
                            }
                            else
                            {
                                #region overheal dmg
                                if (_psm.playerStats.OverHeal)
                                {
                                    if(_psm.playerStats.CurrOverheal > 0)
                                    {
                                        _psm.playerStats.CurrHealth -= Mathf.Abs(dmg - _psm.playerStats.CurrOverheal);
                                        _psm.playerStats.CurrOverheal -= dmg;
                                    }
                                    else
                                    {
                                        _psm.playerStats.CurrHealth -= dmg;
                                    }
                                }
                                else
                                {
                                    _psm.playerStats.CurrHealth -= dmg;
                                }

                                #endregion
                                //Debug.Log("Player has been hit!");

                                //if anger is active
                                if (Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[4]))
                                {
                                    _psm.playerStats.Anger = true;
                                    Player_StatusManager.Instance.playerStats.AngerDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                                }

                                if (_ess.Name == "Ice Thrower Enemy")
                                {
                                    if (_psm.isSlowed == false)
                                    {
                                        _psm.isSlowed = true;
                                    }
                                    _psm.slowedTime = 3;
                                }
                            }
                        }
                        else
                        {
                            #region overheal dmg
                            if (_psm.playerStats.OverHeal)
                            {
                                if (_psm.playerStats.CurrOverheal > 0)
                                {
                                    _psm.playerStats.CurrHealth -= Mathf.Abs(dmg - _psm.playerStats.CurrOverheal);
                                    _psm.playerStats.CurrOverheal -= dmg;
                                }
                                else
                                {
                                    _psm.playerStats.CurrHealth -= dmg;
                                }
                            }
                            else
                            {
                                _psm.playerStats.CurrHealth -= dmg;
                            }
                            #endregion

                            //if anger is active
                            if (Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[4]))
                            {
                                _psm.playerStats.Anger = true;
                                Player_StatusManager.Instance.playerStats.AngerDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                            }

                            if (_ess.Name == "Ice Thrower Enemy")
                            {
                                if (_psm.isSlowed == false)
                                {
                                    _psm.isSlowed = true;
                                }
                                _psm.slowedTime = 3;
                            }
                        }

                    }
                    else
                    {
                        //Debug.Log("Hit something else");
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
