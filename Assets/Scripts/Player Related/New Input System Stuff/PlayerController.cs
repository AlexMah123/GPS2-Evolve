using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Created by Shane, edited by Alex, Yung Zhen

    [HideInInspector] public Player playerInput;
    private Transform cameraMain;
    public CharacterController controller;
    public Vector3 playerVelocity;
    public bool groundedPlayer = true;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float gravityValue = -9.81f;

    public bool attacking;

    public Animator animator;

    public static PlayerController Instance;
    //FSM Stuff
    public PlayerStateMachine currentState;

    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    private void OnEnable()
    {
        playerInput.Enable();
    }

    private void OnDisable()
    {
        playerInput.Disable();
    }

    private void Start()
    {
        cameraMain = Camera.main.transform;
        SetState(new NormalState(this));
    }
    void Update()
    {
        //Debug.Log(groundedPlayer);
        Debug.Log(currentState);

        if (controller.isGrounded)
        {
            groundedPlayer = true;
        }
        if (groundedPlayer)
        {
            playerVelocity.y = 0f;
        }

        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();
        Vector3 move = cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x;
        animator.SetFloat("Running", move != Vector3.zero ? Mathf.Abs(movementInput.magnitude) : 0.01f);
        StartCoroutine(currentState.Movement(move));

        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new(transform.localEulerAngles.x, cameraMain.localEulerAngles.y, transform.localEulerAngles.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);
        }

        #region buttonTriggers
        //Changes the height position of the player..
        if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
        {
            StartCoroutine(currentState.Jump());
            animator.SetBool("Jumping", !groundedPlayer);
        }
        else if (playerInput.PlayerMain.Melee.triggered)
        {
            //Melee code should go in NormalState.Melee
            StartCoroutine(currentState.Melee());
        }
        else if (playerInput.PlayerMain.Devour.triggered)
        {
            StartCoroutine(currentState.Devour());
            
        }
        #endregion

        #region endAnimatorTriggers
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            if ((animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0)) || animator.GetBool("Jumping") == false )
            {
                StartCoroutine(currentState.JumpFinished());
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Idle/Attack"))
        {
            animator.SetFloat("Blend", animator.GetCurrentAnimatorStateInfo(0).normalizedTime * 2);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
            {
                StartCoroutine(currentState.ActionFinished());
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Devour"))
        {
            Debug.Log(animator.GetCurrentAnimatorStateInfo(0).normalizedTime);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
            {
                StartCoroutine(currentState.DevourFinished());
            }
        }
        #endregion
    }
    public void JumpEvent()
    {
        StartCoroutine(currentState.Jump());
        animator.SetBool("Jumping", !groundedPlayer);
    }
    //Function called to change Player State in the FSM
    public void SetState(PlayerStateMachine state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }
}