using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ArmedTree : Tree
{
    public EnemyScriptable ess;
    Player_StatusManager psm;
    public GameObject player;
    public Animator animator
    {
        get => GetComponentInChildren<Animator>();
    }

    public NavMeshAgent nva
    {
        get => GetComponent<NavMeshAgent>();
    }
    public void Awake()
    {
        player = GameObject.Find("Kaiju_right_position");
        psm = Player_StatusManager.Instance;
    }
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Shoot(this.transform,player,nva,ess,psm),
            new Approach(this.transform,player,nva,ess),
            new Patrol(this.transform,player,nva,ess,animator),
        });

        return root;
    }
}
