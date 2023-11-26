using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandController : MonoBehaviour
{
    Vector3 mousePosition;
    [SerializeField]Transform weapon;
    Vector3 direction;
    [SerializeField] PlayerController playerController;
    [SerializeField] Animator playerAnimator;
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

      
            if(playerController.GetComponent<Rigidbody2D>().velocity.x >= 0)
            {
                if(angle > 90 && angle <180)
                {
                    weapon.transform.eulerAngles = new Vector3(0, 0, angle);
                }
            }
  
    }
}
