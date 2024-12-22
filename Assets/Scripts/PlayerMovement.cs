using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;

    // Update is called once per frame
    void Update()
    {
       
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

         // Get the vertical velocity
        float yVelocity = controller.GetVerticalVelocity(); // Assume this method is added in CharacterController2D

        // Pass the vertical velocity to the animator for jumping/falling transition
        animator.SetFloat("yVelocity", yVelocity);

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }
    }
    
    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
