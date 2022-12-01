using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{
    //Created by Shane, edited by Alex, Yung Zhen, Terrence

    public static PlayerController Instance;

    [Header("Player Related Stats")]
    [HideInInspector] public Player playerInput;
    [HideInInspector] public CharacterController controller;
    public Vector3 playerVelocity;
    private Transform cameraMain;

    public List<GameObject> deathbodyList;
    public float playerSpeed = 2.0f;
    public float jumpHeight = 1.0f;
    public float jumpForce = 3.0f;
    public float gravityValue = -9.81f;
    public bool inRangeDevour;
    public int attackMomentum = 3;
    public float attackMomentumDuration = 0.3f;

    [Header("Boolean States")]
    [HideInInspector] public bool lookAt;
    public bool attacking = false;
    public bool devouring = false;
    public bool jumping = false;
    public bool dying = false;

    [Header("Skill states")]
    public bool skillActive = false;
    public bool biteActive = false;
    public bool roarActive = false;
    public bool dashActive = false;
    public bool smashActive = false;
    public bool whipActive = false;
    public bool leapsmashActive = false;

    [Header("Animator + Mesh")]
    public Animator animator;

    [Header("FSM")]
    public PlayerStateMachine currentState;

    Vector2 movementInput;

    private void Awake()
    {
        playerInput = new Player();
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
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
        #region enemyRange
        //checks if you are in range, based on collision(trigger)
        inRangeDevour = deathbodyList.Count > 0 ? inRangeDevour = true : inRangeDevour = false;

        //if you are devouring and in range, look at the body
        if(devouring && inRangeDevour)
        {
            Vector3 dir = (deathbodyList[0].transform.position - transform.position).normalized;

            if (lookAt)
            {
                Quaternion lookRotation = Quaternion.LookRotation(dir, Vector3.up);
                transform.localRotation = Quaternion.Euler(0, lookRotation.eulerAngles.y, 0);
                transform.position = deathbodyList[0].transform.position;
                lookAt = false;
            }
        }
        #endregion

        #region movement
        //if you are grounded, apply less force, else apply full force
        if (controller.isGrounded && !jumping)
        {
            playerVelocity.y = gravityValue * 0.05f;
        }
        else if(!controller.isGrounded)
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        if (!devouring && !attacking && !skillActive)
        {
            movementInput = playerInput.PlayerMain.Move.ReadValue<Vector2>();

            if (Player_StatusManager.Instance.isSlowed == true)
            {
                movementInput = movementInput * 0.6f;
            }

            Vector3 move = cameraMain.forward * movementInput.y + cameraMain.right * movementInput.x;
            animator.SetFloat("Running", move != Vector3.zero ? Mathf.Abs(movementInput.magnitude) : 0.01f);
            StartCoroutine(currentState.Movement(move));
        }

        controller.Move(playerVelocity * Time.deltaTime);

        if (movementInput != Vector2.zero)
        {
            Quaternion rotation = Quaternion.Euler(new(transform.localEulerAngles.x, cameraMain.localEulerAngles.y, transform.localEulerAngles.z));
            transform.rotation = Quaternion.Lerp(transform.rotation, rotation, Time.deltaTime * 5);
        }
        #endregion

        #region buttonTriggers
        //Changes the height position of the player..
        if (playerInput.PlayerMain.Jump.triggered && controller.isGrounded)
        {
            StartCoroutine(currentState.Jump());
            animator.SetBool("Jumping", true);
        }
        else if (playerInput.PlayerMain.Melee.triggered)
        {
            //Melee code should go in NormalState.Melee
            if(!animator.GetBool("NormalAttack"))
            {
                StartCoroutine(currentState.Melee());
            }
            else if(animator.GetBool("NormalAttack"))
            {
                animator.SetTrigger("SecondAttack");
            }
            
        }
        else if (playerInput.PlayerMain.Devour.triggered && inRangeDevour)
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
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("LSlash") || this.animator.GetCurrentAnimatorStateInfo(0).IsName("RSlash"))
        {
            animator.SetFloat("Blend", animator.GetCurrentAnimatorStateInfo(0).normalizedTime * 2);
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
            {
                StartCoroutine(currentState.ActionFinished());
            }
        }
        if (this.animator.GetCurrentAnimatorStateInfo(0).IsName("Devour"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1 && !animator.IsInTransition(0))
            {
                StartCoroutine(currentState.DevourFinished());
            }
        }
        #endregion

        //Death
        if(Player_StatusManager.Instance.playerStats.CurrHealth <= 0)
        {
            StartCoroutine(currentState.Death());
        }

    }

    //Function called to change Player State in the FSM
    public void SetState(PlayerStateMachine state)
    {
        currentState = state;
        StartCoroutine(currentState.Start());
    }

    #region CollisionRelated
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Deadbody"))
        {
            deathbodyList.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.CompareTag("Deadbody"))
        {
            deathbodyList.Remove(other.gameObject);
        }
    }

    #endregion

    public void JumpNow()   
    {
        jumping = true;
        playerVelocity.y += Mathf.Abs(jumpHeight * gravityValue / jumpForce);
    }
    public void LeapNow()
    {
        jumping = true;
        playerVelocity.y += Mathf.Abs(jumpHeight * gravityValue / jumpForce)/3.1f;
    }
    public void PlayAudio(string clip)
    {
        AudioManager.Instance.PlaySound(clip);
    }
    public IEnumerator AttackNow()
    {
        playerVelocity = attackMomentum * transform.forward;
        yield return new WaitForSeconds(attackMomentumDuration);
        
        playerVelocity = Vector3.zero;
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(hit.gameObject.CompareTag("Enemy"))
        {
            controller.slopeLimit = 30;
        }
        else
        {
            controller.slopeLimit = 40;
        }
    }
}