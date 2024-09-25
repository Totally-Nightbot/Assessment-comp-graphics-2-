using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbox : MonoBehaviour
{
    public void OnTriggerEnter(Collider other) //checks when the player enters the collider
    {
        var ragdoller =
        other.gameObject.GetComponent<Ragdoll>(); //checks if there is a ragdoll component on the player
        if (ragdoller != null)
        {
            ragdoller.RagdollOn(); //plays the RagdollOn method 
        }
    }
}
