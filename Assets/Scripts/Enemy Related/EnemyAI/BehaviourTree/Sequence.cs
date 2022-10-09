using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HYZ
    public class Sequence : Node //And logic gate
    {
        public Sequence() : base() { }
        public Sequence(List<Node> children) : base(children) { }
        public override NodeState Evaluate()
        {
            bool running = false;
            foreach (Node n in children)
            {
                switch (n.Evaluate())
                {
                    case NodeState.FAILURE:
                        state = NodeState.FAILURE;
                        return state;

                    case NodeState.SUCCESS:
                        state = NodeState.SUCCESS; // Might not need
                        continue;

                    case NodeState.RUNNING:
                        running = true;
                        continue;

                    default:
                        state = NodeState.SUCCESS;
                        return state;
                }
            }
            state = running ? NodeState.RUNNING : NodeState.SUCCESS; 
            return state;
        }
    }

