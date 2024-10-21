using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
    public Player player;

    private void Update()
    {
        if (player.keyGet == true)
        {
            player.colliding = false;
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        player.colliding = true;
        Debug.Log("ENTERED FUCKHEAD");
    }
    private void OnTriggerExit(Collider other)
    {
        player.colliding = false;
    }
}