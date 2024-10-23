using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public Player player;
    public GameObject particles;
    public int hitmarkers;

    private void Update()
    {
        if (hitmarkers >= 3) // checks if hitmarkers is over 3 or not and if it is deletes the game object (and plays the particle system) 
        {
            particles.gameObject.SetActive(true);
            Debug.Log("deleting cuz over 3");
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(player.keyGet == true) //checks if the player has the key and if they do then deletes the game object (and plays the particle system) 

        {
            particles.gameObject.SetActive(true);
            Destroy(gameObject);
        }  
    }
}
