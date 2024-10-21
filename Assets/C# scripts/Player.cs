using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [HideInInspector] public Animator animator;
    private Vector2 moveInput;  
    private CharacterController characterController;
    private bool playParticle = false;

    
    public ParticleSystem particledust;
    [HideInInspector] public bool colliding = false;
    [HideInInspector] public bool keyGet;
    private bool stop;
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

        if (keyGet == true && stop == false)
        {
            Debug.Log("key Recived");
            stop = true;
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

        public void OnPickup(InputAction.CallbackContext context) //when E is pressed then remove object from game and give the player a key.
    {
        if (context.started)
        {
           
            if (colliding == true)
            {
                animator.SetBool("pickUp", true); //set the bool of dancing to true
                Debug.Log("pickingUp");
                keyGet = true;
                colliding = true;
            }
        }
        else if (context.canceled)
        {
            animator.SetBool("pickUp", false); //set the bool of dancing to false
        }

    }


    }

