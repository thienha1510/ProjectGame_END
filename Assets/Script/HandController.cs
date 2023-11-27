using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField] Transform weapon;
    Vector3 direction;
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator playerAnimator;

    [SerializeField] SpriteRenderer playerSpriteRenderer;
    [SerializeField] SpriteRenderer weaponSpriteRenderer;
    [SerializeField] GameObject bullet;
    [SerializeField] Transform firePos;
    //  [SerializeField] Transform firePos;

    // Start is called before the first frame update
    private void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        handRotation();

    }

    void handRotation()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = (mousePosition - weapon.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        //weapon.transform.eulerAngles = new Vector3(0, 0, angle);


        if (playerController.GetComponent<Rigidbody2D>().velocity.x >= 0)

            // firePos.transform.position = weapon.transform.position;
            weapon.transform.eulerAngles = new Vector3(0, 0, angle);

        // Debug.Log(angle);
        //Right
        if ((angle > -45 && angle < 0) || (angle < 45 && angle > 0))
        {
            //PlayerController.ResetMovingBool();
            if (PlayerController.moveInput.x == 0)
            {
                if (angle > 90 && angle < 180)
                {
                    weapon.transform.eulerAngles = new Vector3(0, 0, angle);
                }
            }
            else
            {
                //PlayerController.playerHasHorizontalSpeed = true;
            }
            playerSpriteRenderer.flipX = false;
            weaponSpriteRenderer.flipY = false;
        }
        //Left
        if ((angle > -225 && angle < -135) || (angle < 225 && angle > 135))
        {
            //PlayerController.ResetMovingBool();
            if (PlayerController.moveInput.x == 0)
            {
                PlayerController.playerHasHorizontalIdle = true;
            }
            else
            {
                PlayerController.playerHasHorizontalSpeed = true;
            }
            playerSpriteRenderer.flipX = true;
            weaponSpriteRenderer.flipY = true;
        }
        //Up
        if (angle < 135 && angle > 45)
        {
            //PlayerController.ResetMovingBool();
            if (PlayerController.moveInput.y == 0)
            {
                PlayerController.playerHasVerticalIdle_Up = true;
            }
            else
            {

                PlayerController.playerHasVerticalSpeed_Up = true;
            }


        }
        //Down
        if (angle > -135 && angle < -45)
        {
            //PlayerController.ResetMovingBool();
            if (PlayerController.moveInput.y == 0)
            {
                PlayerController.playerHasVerticalIdle_Down = true;
            }
            else
            {
                PlayerController.playerHasVerticalSpeed_Down = true;

            }

        }
    }
    void Shoot()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0;
        direction = (mousePosition - firePos.transform.position).normalized;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        // firePos.transform.eulerAngles = new Vector3(0, 0, angle);
        // direction = 
        if (Input.GetMouseButtonDown(0))
        {
            GameObject test = Instantiate(bullet, firePos.position, firePos.rotation);

        }
    }
}
