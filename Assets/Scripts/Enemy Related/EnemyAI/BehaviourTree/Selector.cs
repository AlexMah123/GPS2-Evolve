using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Selector : Node // OR LOGIC GATE
{
    public Selector() : base() {}
    public Selector (List<Node> children) : base(children){ }
    public override NodeState Evaluate()
    {
        foreach (Node n in children)
        {
            switch (n.Evaluate())
            {
                case NodeState.SUCCESS:
                    state = NodeState.SUCCESS;
                    return state;
                case NodeState.RUNNING:
                    state = NodeState.RUNNING;
                    return state;
                case NodeState.FAILURE:
                    continue;
                default:
                    continue;
            }
        }
        state = NodeState.FAILURE;
        return state;
    }
}

