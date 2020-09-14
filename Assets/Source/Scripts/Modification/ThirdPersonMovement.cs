using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;

    public float speed = 5f;
    public float belokSmootingTime = 0.1f;
    public float jumpSpeed = 4f;
    public float secondJumpSpeed = 0.6f;

    public float gravity = 9.81f;

    float turnSmoothVelocity;
    float jumpAxis;

    bool isDoubleJump = false;

    // Update is called once per frame
    void Update()
    {
        float hAxis = Input.GetAxisRaw("Horizontal");
        float vAxis = Input.GetAxisRaw("Vertical");
        Vector3 arah = new Vector3(hAxis, 0f, vAxis).normalized;


        if (arah.magnitude >= 0.1f)
        {
            float radiusPutar = Mathf.Atan2 (arah.x, arah.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float radiusSmooth = Mathf.SmoothDampAngle(transform.eulerAngles.y, radiusPutar, ref turnSmoothVelocity, belokSmootingTime);

            transform.rotation = Quaternion.Euler(0f, radiusSmooth, 0f);
            
            if (controller.isGrounded)
            {
                isDoubleJump = true;
                
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    jumpAxis = jumpSpeed;
                    Debug.Log("Space is pressed");
                }
            }else
            {
                if (Input.GetKeyDown(KeyCode.Space) && isDoubleJump) 
                {
                    jumpAxis = jumpSpeed * secondJumpSpeed;
                    isDoubleJump = false;
                    Debug.Log("Space is pressed");

                }
            }

            jumpAxis -= gravity * Time.deltaTime;

            arah.y = jumpAxis;

            Vector3 arahGerak = Quaternion.Euler(0f, radiusPutar, 0f) * Vector3.forward;

            controller.Move(arahGerak.normalized * speed * Time.deltaTime);
        }


    }
}
