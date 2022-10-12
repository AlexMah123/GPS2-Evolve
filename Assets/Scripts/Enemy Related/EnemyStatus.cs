using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Shane
public class EnemyStatus : MonoBehaviour
{
    public EnemyScriptable ess;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Collided");
        }
    }
}
