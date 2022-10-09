using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//HYZ
[RequireComponent(typeof(NavMeshAgent))]
public class PatrolTree : Tree
{
    public Enemy_Base scriptableEnemy;
    public EnemySpawnerScriptable ess;
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
         new Run(this.transform,player,nva),
         new Walk(player, this.transform, nva),
    }); ; ;
        
        return root;
    }
}
