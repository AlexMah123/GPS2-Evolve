using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnarmedTree : Tree
{
    public Enemy_Base scriptableEnemy;
    public override Node SetupTree()
    {
        Node root = new Selector(new List<Node>
        {
            new Walk(),
        });
        
        return root;
    }
}
