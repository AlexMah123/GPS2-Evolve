using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
[RequireComponent(typeof(NavMeshAgent))]
public class PatrolTree : Tree
{
    public EnemyScriptable ess;
    public GameObject player;
    public NavMeshAgent nva
    {
        get => GetComponent<NavMeshAgent>();
    }
    public void Awake()
    {
        Debug.Log(ess.spawnCount);
        player = GameObject.Find("Kaiju_right_position");
    }
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
         new Run(this.transform,player,nva,ess),
         new Walk(this.transform,player,nva,ess),
    }); ; ;
        
        return root;
    }
}
