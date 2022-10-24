using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class ArmedTree : Tree
{
    public EnemyScriptable ess;
    public Player_Base pb;
    public GameObject player;
    public NavMeshAgent nva
    {
        get => GetComponent<NavMeshAgent>();
    }
    public void Awake()
    {
        player = GameObject.Find("Kaiju_right_position");
    }
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Shoot(this.transform,player,nva,ess,pb),
            new Approach(this.transform,player,nva,ess),
            new Patrol(this.transform,player,nva,ess),
        });

        return root;
    }
}
