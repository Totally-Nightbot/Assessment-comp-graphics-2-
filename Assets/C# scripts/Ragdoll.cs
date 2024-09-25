using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

private Animator animator;

   [SerializeField] public bool on;

    public void RagdollOn() //disables the animator and movement physics 
    {
        on = true;
        animator.enabled = false;
    }
    void Start() // gets the animator component
    {
        animator = GetComponent<Animator>();
    }
    
}