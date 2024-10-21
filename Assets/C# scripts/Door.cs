using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
   public Player player;
    public GameObject particles;

    private void OnTriggerEnter(Collider other)
    {
        if(player.keyGet == true)
        {
            particles.gameObject.SetActive(true);
            Destroy(gameObject);
        }  
    }
}
