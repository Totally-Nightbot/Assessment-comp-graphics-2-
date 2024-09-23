using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ragdoll : MonoBehaviour
{

private Animator animator;

   [SerializeField] public bool on;

    public void RagdollOn()
    {
        on = true;
        animator.enabled = false;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    
}