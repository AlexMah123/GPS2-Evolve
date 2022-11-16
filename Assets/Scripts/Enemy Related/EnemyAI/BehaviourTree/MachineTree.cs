using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ, modified by terrence
[RequireComponent(typeof(NavMeshAgent)), RequireComponent(typeof(EnemyStatus))]
public class MachineTree : Tree
{
    public EnemyScriptable ess;
    public GameObject player;
    Player_StatusManager psm;
    public Animator Animator
    {
        get => GetComponentInChildren<Animator>();
    }
    public NavMeshAgent Nva
    {
        get => GetComponent<NavMeshAgent>();
    }
    private bool DMGReady = true;
    private float DMGTime;
    private float DMGTimeMax = 4;

    public void Awake()
    {
        player = GameObject.Find("Kaiju");
        psm = Player_StatusManager.Instance;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject == player && DMGReady)
        {
            int dmg;
            dmg = ess.Attack - psm.playerStats.Defence;
            if (dmg < 0)
            {
                dmg = 0;
            }
            DMGReady = false;
            DMGTime = 0;

            //if block is active, run the effect
            if (psm.playerStats.Block)
            {
                int rand = Random.Range(0, 100);

                //if the chance of block is hit
                if (rand < psm.playerStats.BlockChance * 100)
                {
                    Debug.Log("Blocked!");
                }
                else
                {
                    #region overheal dmg
                    if (psm.playerStats.OverHeal)
                    {
                        if (psm.playerStats.CurrOverheal > 0)
                        {
                            psm.playerStats.CurrHealth -= Mathf.Abs(dmg - psm.playerStats.CurrOverheal);
                            psm.playerStats.CurrOverheal -= dmg;
                        }
                        else
                        {
                            psm.playerStats.CurrHealth -= dmg;
                        }
                    }
                    else
                    {
                        psm.playerStats.CurrHealth -= dmg;
                    }

                    #endregion
                    //Debug.Log("Player has been hit!");

                    //if anger is active
                    if (Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[4]))
                    {
                        psm.playerStats.Anger = true;
                        Player_StatusManager.Instance.playerStats.AngerDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                    }
                }
            }
            else
            {
                #region overheal dmg
                if (psm.playerStats.OverHeal)
                {
                    if (psm.playerStats.CurrOverheal > 0)
                    {
                        psm.playerStats.CurrHealth -= Mathf.Abs(dmg - psm.playerStats.CurrOverheal);
                        psm.playerStats.CurrOverheal -= dmg;
                    }
                    else
                    {
                        psm.playerStats.CurrHealth -= dmg;
                    }
                }
                else
                {
                    psm.playerStats.CurrHealth -= dmg;
                }
                #endregion

                //if anger is active
                if (Player_PerksManager.Instance.selectedModList.Contains(Player_PerksManager.Instance.totalModList[4]))
                {
                    psm.playerStats.Anger = true;
                    Player_StatusManager.Instance.playerStats.AngerDuration = 3 + Player_StatusManager.Instance.playerStats.BuffExtend;
                }
            }
        }
    }
    /*private void Update()
    {
        SetupTree();
        if (DMGTime >= DMGTimeMax && !DMGReady)
        {
            DMGReady = true;
        }
        else
        {
            DMGTime += Time.deltaTime;
        }
    }*/

    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Charge(this.transform,player,Nva,ess,Animator,psm),
            new Patrol(this.transform,player,Nva,ess,Animator),
        });

        return root;
    }
}
