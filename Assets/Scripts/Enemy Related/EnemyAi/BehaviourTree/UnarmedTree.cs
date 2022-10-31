using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
[RequireComponent(typeof(NavMeshAgent)),RequireComponent(typeof(EnemyStatus))]
public class UnarmedTree : Tree
{
    public EnemyScriptable ess;
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
        player = GameObject.Find("Kaiju");
    }
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Run(this.transform,player,nva,ess,animator),
            new Patrol(this.transform,player,nva,ess,animator),
        });
        
        return root;
    }
}
