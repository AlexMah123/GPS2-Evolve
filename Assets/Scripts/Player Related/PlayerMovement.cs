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

    //Joystick declare
    [SerializeField] Joystick joystick;

    //basis for moving 

    private void Update()
    {
        direction = joystick.Direction;
        Move();
    }

    private void Move()
    {
        direction = direction.normalized;
        rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.y * speed);
    }

}
