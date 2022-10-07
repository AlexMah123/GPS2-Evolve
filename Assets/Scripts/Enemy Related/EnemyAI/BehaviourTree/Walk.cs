using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walk : Node
{
    public override NodeState Evaluate()
    {
        Debug.Log("walking");
        state = NodeState.RUNNING;
        return state;
    }
}
