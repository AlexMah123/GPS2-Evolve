using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public abstract class Tree : MonoBehaviour
    {
        private Node root = null;
        private void Start()
        {
            root = SetupTree();
        }
        private void Update()
        {
            if (root != null)
                root.Evaluate();
            
        }

        public abstract Node SetupTree();
    }
