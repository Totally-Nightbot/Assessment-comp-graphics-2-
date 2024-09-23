using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
  
private Animator animator;
    private Vector2 moveInput;  
    private CharacterController characterController;

    public float moveSpeed = 5f;
    public Ragdoll ragdoll;

    void Start()
    {
        Physics.IgnoreLayerCollision(6, 7, true);

        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (ragdoll.on == false)
        {
            Vector3 move = new Vector3(moveInput.x, 0, moveInput.y) *
            moveSpeed * Time.deltaTime;
            characterController.Move(move);
            // Update the animator with the movement speed
            animator.SetFloat("x", moveInput.x * moveSpeed);
            animator.SetFloat("y", moveInput.y * moveSpeed);
        }
    }

    
    public void OnDance(InputAction.CallbackContext context)
    { 
    if (context.started)
    {
    animator.SetBool("dancing", true);
    }
        else if (context.canceled)
        {
        animator.SetBool("dancing", false);
        }

    } 
    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
    }


}

