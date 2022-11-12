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
    public void Awake()
    {
        player = GameObject.Find("Kaiju");
        psm = Player_StatusManager.Instance;
    }
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
