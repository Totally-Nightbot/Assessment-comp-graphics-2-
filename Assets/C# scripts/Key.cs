using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (player.keyGet == true) //checks if the player has collected the key, if it does then destroys the gameobject
        {
            player.colliding = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other) //checks if the player is in the collider or not 
    {
        player.colliding = true;
    }
    private void OnTriggerExit(Collider other) //checks if the player is in the collider or not 
    {
        player.colliding = false;
    }
}