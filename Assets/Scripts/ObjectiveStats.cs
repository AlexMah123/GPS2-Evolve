using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveStats : MonoBehaviour
{
    public bool isDestroyed = false;
    [SerializeField] int objectiveHealth;
    [SerializeField] float delayTimer;

    bool delay;

    private void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

}
