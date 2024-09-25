using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    private bool incollider = false; 
    float speed = 1.0f;

   public GameObject collidercheck;

    public Transform destination;
    private void OnTriggerEnter(Collider other) //when player enters the collider
    {
        if(other.gameObject == collidercheck) // if the colliding entity is the same as the collider check gameobject then run
        {
            Transform character = other.transform.parent; //parents the player to the moving platform
            character.SetParent(transform);
            incollider = true;
            Debug.Log("collided");
        }
       
    }

    private void Update()
    {
        if (incollider == true) //syncs the transforms of the platform and the player and moves the platform to the destination
        {
            transform.position = Vector3.MoveTowards(transform.position, destination.position, Time.deltaTime * speed);
            Physics.SyncTransforms();
        }
    }
}
