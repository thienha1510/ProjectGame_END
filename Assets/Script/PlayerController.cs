using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //Player settings
    [SerializeField] float moveSpeed;
    [SerializeField] SpriteRenderer spriteRenderer;
    bool isAlive;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    //Moving
    static bool playerHasHorizontalIdle = false;
    static bool playerHasHorizontalSpeed = false;
    static bool playerHasVerticalSpeed_Up = false;
    static bool playerHasVerticalSpeed_Down = false;
    static bool playerHasVerticalIdle_Up = false;
    static bool playerHasVerticalIdle_Down = false;

    //
    [SerializeField]PlayerInput playerInput;
    Vector2 moveInput;
    private void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        capsuleCollider2D = GetComponent<CapsuleCollider2D>();
    }
    // Start is called before the first frame update
    void Start()
    {
        isAlive = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isAlive == false)
        {
            return;
        }
        Run();
        FlipSprite();
    }
    void OnMove(InputValue value)
    {
        if(isAlive ==  false)
        {
            return;
        }
        
        moveInput = value.Get<Vector2>();
    }
    void ResetMovingBool()
    {
        animator.SetBool("HMoving", false);
        animator.SetBool("VMoving_Up", false);
        animator.SetBool("VMoving_Down", false);

        animator.SetBool("HIdle", false);
        animator.SetBool("VIdle_Up", false);
        animator.SetBool("VIdle_Down", false);

    }
    void Run()
    {
        
        Vector2 playerVelocity = new Vector2(moveInput.x * moveSpeed, moveInput.y * moveSpeed);
        rigidbody2D.velocity = playerVelocity;
        playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;
        playerHasVerticalSpeed_Up = moveInput.y > 0;
        playerHasVerticalSpeed_Down = moveInput.y < 0;

        /////Run Animations
        if (moveInput.x == 0 && moveInput.y == 0)
        {
            ResetMovingBool();
        }
        //Horizon
        if (playerHasHorizontalSpeed == true)
        {
            ResetMovingBool();
            animator.SetBool("HMoving", playerHasHorizontalSpeed);
            playerHasHorizontalIdle = true;
        }
        else 
        {
            if (playerHasHorizontalIdle == true)
            {
                ResetMovingBool();
                animator.SetBool("HIdle", true);
                playerHasHorizontalIdle = false;
            }
        }
        //Vertical_Up
        if (playerHasVerticalSpeed_Up == true || (playerHasVerticalSpeed_Up == true && playerHasHorizontalSpeed == true))
        {
            ResetMovingBool();
            // animator.SetBool("HMoving", false);
            animator.SetBool("VMoving_Up", playerHasVerticalSpeed_Up);
            playerHasVerticalIdle_Up = true;

        }
        else
        {
            if (playerHasVerticalIdle_Up == true)
            {
                ResetMovingBool();
                animator.SetBool("VIdle_Up", true);
                playerHasVerticalIdle_Up = false;
            }
        }
        //Vertical_Down
        if (playerHasVerticalSpeed_Down == true || (playerHasVerticalSpeed_Down == true && playerHasHorizontalSpeed == true))
        {
            ResetMovingBool();
           // animator.SetBool("HMoving", false);
            animator.SetBool("VMoving_Down", playerHasVerticalSpeed_Down);
            playerHasVerticalIdle_Down = true;

        }
        else
        {
            if (playerHasVerticalIdle_Down == true)
            {
                ResetMovingBool();
                animator.SetBool("VIdle_Down", true);
                playerHasVerticalIdle_Down = false;
            }
        }
       

     
    }
    void FlipSprite()
    {
        playerHasHorizontalSpeed = Mathf.Abs(rigidbody2D.velocity.x) > Mathf.Epsilon;

        
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            spriteRenderer.flipX = true;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            spriteRenderer.flipX = false;
        }
    
    
    }
}
