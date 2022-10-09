using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//HYZ
    public enum NodeState
    {
        RUNNING,
        SUCCESS,
        FAILURE
    }
    public class Node
    {
        public NodeState state;
        public Node parent;
        public List<Node> children = new List<Node>();

        public Node()
        {
            parent = null;
        }
        public Node(List<Node> children)
        {
            foreach (Node c in children)
                Attach(c);
        }
        private void Attach(Node node)
        {
            node.parent = this;
            children.Add(node);
        }

        public virtual NodeState Evaluate() => NodeState.FAILURE;
    }

