using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerController : MonoBehaviour
{
    //Player settings
    [SerializeField] float moveSpeed;
    [SerializeField] public SpriteRenderer spriteRenderer;
    bool isAlive;
    [SerializeField] Rigidbody2D rigidbody2D;
    [SerializeField] Animator animator;
    CapsuleCollider2D capsuleCollider2D;
    //Moving
    public static bool playerHasHorizontalIdle = false;
    public static bool playerHasHorizontalSpeed = false;
    public static bool playerHasVerticalSpeed_Up = false;
    public static bool playerHasVerticalSpeed_Down = false;
    public static bool playerHasVerticalIdle_Up = false;
    public static bool playerHasVerticalIdle_Down = false;

    //
    [SerializeField] PlayerInput playerInput;
    public static Vector2 moveInput;
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
        if (isAlive == false)
        {
            return;
        }
        Run();
        //  FlipSprite();
    }
    void OnMove(InputValue value)
    {
        if (isAlive == false)
        {
            return;
        }

        moveInput = value.Get<Vector2>();
    }
    public void ResetMovingBool_Anim()
    {
        animator.SetBool("HMoving", false);
        animator.SetBool("VMoving_Up", false);
        animator.SetBool("VMoving_Down", false);

        animator.SetBool("HIdle", false);
        animator.SetBool("VIdle_Up", false);
        animator.SetBool("VIdle_Down", false);

    }
    public static void ResetMovingBool()
    {
        playerHasHorizontalSpeed = false;
        playerHasVerticalSpeed_Down = false;
        playerHasVerticalSpeed_Up = false;
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
            ResetMovingBool_Anim();
        }
        //Horizontal
        if (playerHasHorizontalSpeed == true && (playerHasVerticalSpeed_Up == false && (playerHasVerticalSpeed_Up == false)))
        {
            ResetMovingBool_Anim();
            animator.SetBool("HMoving", playerHasHorizontalSpeed);
            playerHasHorizontalIdle = true;
        }
        if (playerHasHorizontalIdle == true && moveInput.x == 0)
        {
            ResetMovingBool_Anim();
            animator.SetBool("HIdle", true);
            playerHasHorizontalIdle = false;
        }
        else 
        {
            if (playerHasHorizontalIdle == true && moveInput.x == 0)
            {
                ResetMovingBool_Anim();
                animator.SetBool("HIdle", true);
                playerHasHorizontalIdle = false;
            }
        }
        //Vertical_Up
        if (playerHasVerticalSpeed_Up == true || (playerHasVerticalSpeed_Up == true && playerHasHorizontalSpeed == true))
        {
            ResetMovingBool_Anim();
            // animator.SetBool("HMoving", false);
            animator.SetBool("VMoving_Up", playerHasVerticalSpeed_Up);
            playerHasVerticalIdle_Up = true;

        }
        else
        {
            if (playerHasVerticalIdle_Up == true && moveInput.y == 0)
            {
                ResetMovingBool_Anim();
                animator.SetBool("VIdle_Up", true);
                playerHasVerticalIdle_Up = false;
            }
        }
        //Vertical_Down
        if (playerHasVerticalSpeed_Down == true || (playerHasVerticalSpeed_Down == true && playerHasHorizontalSpeed == true))
        {
            ResetMovingBool_Anim();
            // animator.SetBool("HMoving", false);
            animator.SetBool("VMoving_Down", playerHasVerticalSpeed_Down);
            playerHasVerticalIdle_Down = true;

        }
        else
        {
            if (playerHasVerticalIdle_Down == true && moveInput.y == 0)
            {
                ResetMovingBool_Anim();
                animator.SetBool("VIdle_Down", true);
                playerHasVerticalIdle_Down = false;
            }
        }



    }
    /*    void FlipSprite()
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


        }*/
    //void Shoot()
    //{
    //    mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //    mousePosition.z = 0;
    //    direction = (mousePosition - firePos.transform.position).normalized;

    //    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
    //   // firePos.transform.eulerAngles = new Vector3(0, 0, angle);
    //    // direction = 
    //    if (Input.GetMouseButtonDown(0))
    //    {
    //        GameObject test = Instantiate(bullet, firePos.position, firePos.rotation);

    //    }
    //}

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
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            spriteRenderer.flipY = true;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            spriteRenderer.flipY = false;
        }
    }
}
