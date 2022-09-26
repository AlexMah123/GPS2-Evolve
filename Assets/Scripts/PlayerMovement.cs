using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //Created by Terrence

    //[SerializeField] private GameObject player;
    [SerializeField] private Vector2 direction;
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody rb;

    //basis for moving 

    private void Update()
    {
        direction = direction.normalized;
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);
    }

}
