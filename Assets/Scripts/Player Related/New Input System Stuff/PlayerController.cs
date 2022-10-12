using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Created by Shane

    [HideInInspector] public Player playerInput;
    private Transform cameraMain;
    private CharacterController controller;
    [SerializeField] Vector3 playerVelocity;
    [SerializeField] private bool groundedPlayer = true;
    [SerializeField] private float playerSpeed = 2.0f;
    [SerializeField] private float jumpHeight = 1.0f;
    [SerializeField] private float gravityValue = -9.81f;

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
        //Debug.Log(currentState);

        if(controller.isGrounded)
        {
            groundedPlayer = true;
        }

        if (groundedPlayer)
        {
            playerVelocity.y = 0f;
        }


        Vector2 movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>() ;
        Vector3 move = cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x;
        animator.SetFloat("Running", movementInput.y);
        move.y = 0;
        controller.Move(playerSpeed * Time.deltaTime * move);
        if (move != Vector3.zero)
        {
            //gameObject.transform.forward = move;
        }

        // Changes the height position of the player..
        if (playerInput.PlayerMain.Jump.triggered && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            groundedPlayer = false;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new(transform.localEulerAngles.x, cameraMain.localEulerAngles.y, transform.localEulerAngles.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);
        }


        if (playerInput.PlayerMain.Melee.triggered)
        {
            //Melee code should go in NormalState.Melee
            animator.SetBool("NormalAttack", true);
            StartCoroutine(currentState.Melee());
        }

        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Melee"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1 && !animator.IsInTransition(0))
            {
                StartCoroutine(currentState.ActionFinished());
            }
        }
    }

    //Function called to change Player State in the FSM
    public void SetState(PlayerStateMachine state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }
}
