using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : BaseCharacter
{
    public CharacterController2D Controller;

    float horizontalMove = 0f;
    float runSpeed = 20f;

    bool jump = false;
    bool crouch = false;


    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jump", jump);
        }
 
        if (Input.GetAxisRaw("Crouch") > 0 && Mathf.Abs(horizontalMove) == 0)
        {
            crouch = true;
        }
        else
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {
        Controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

    public void OnLanding()
    {
        animator.SetBool("Jump", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("Crouch", isCrouching);
    }

    public override void Die()
    {
        base.Die();
        //TODO: Replace this with a game over screen and a option to load Start screen.
        SceneManager.LoadScene(0);
    }
}
