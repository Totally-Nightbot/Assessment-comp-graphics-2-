using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  
private Animator animator;
    private Vector2 moveInput;  
    private CharacterController characterController;

    public float sprint = 2.5f; // The sprint speed
    public float moveSpeed = 5f; // Movement speed
    public float speed;
    public Ragdoll ragdoll;

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7, true); // ensures the player controller doesn't collide with the ragdoll

        animator = GetComponent<Animator>(); // gets and sets the animator  and the character controller 
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ragdoll.on == false) //If the ragdoll is true then it stops all movement 
        {
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) * //creates a new vector based on the inputs from the keyboard
            moveSpeed * Time.deltaTime;
            characterController.Move(move);
          
            animator.SetFloat("x", moveInput.x * moveSpeed);  // Update the animator with the movement speed
            animator.SetFloat("y", moveInput.y * moveSpeed);
          

        }
    }

    public void OnSprint(InputAction.CallbackContext context) //When the shift button is held, this will run
    {
        if(context.started) //on hold, speed holds the moveSpeed variable and then multiplies the moveSpeed by sprint
        {
            speed = moveSpeed; 
            moveSpeed = moveSpeed * sprint;
        }
           else if (context.canceled) //When shift is lifted then return movespeed back to the original value 
        {
            moveSpeed = speed;
        }

    }

    public void OnCrouch(InputAction.CallbackContext context) //when crouch is held 
    {
        if (context.started)
        {
            animator.SetBool("crouch", true); //set the bool of crouch to true 
        }
        else if (context.canceled)
        {
            animator.SetBool("crouch", false); //set the bool of crouch to false 
        }
    }

    public void OnDance(InputAction.CallbackContext context) //When 1 is pressed play the dance
    { 
    if (context.started)
    {
    animator.SetBool("dancing", true); //set the bool of dancing to true 
    }
        else if (context.canceled)
        {
        animator.SetBool("dancing", false); //set the bool of dancing to false 
        }

    } 
    public void OnMove(InputAction.CallbackContext context) //reads the inputs put in from the keyboard
    {
        moveInput = context.ReadValue<Vector2>();
    }

  


}

