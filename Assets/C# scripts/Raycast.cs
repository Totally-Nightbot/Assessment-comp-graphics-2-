using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Raycast : MonoBehaviour
{
    public LineRenderer line; 
    public Door door; 
    Ray ray;
    public GameObject origin;
    public GameObject laserhit;

    private void Update()
    {
        ray = new Ray(origin.transform.position, origin.transform.forward); // initialises the ray from the player moving forward 

        if (Input.GetMouseButtonDown(0)) // gets the players input from the mouse 
        {
            if (Physics.Raycast(ray, out RaycastHit hit)) // if the ray was to hit something 
            {
                line.enabled = true; // enables the line renderer and then sets the position from the player to the hitpoint
                line.SetPosition(0, origin.transform.position);
                line.SetPosition(1, hit.point);
                Invoke("lineDisable", 0.5f); // waits 0.5 seconds before turining off the line renderer and particle system 

                laserhit.transform.position = hit.point; // places the particle system to the position of the hit and sets it active
                laserhit.gameObject.SetActive(true);


                if (hit.collider.gameObject.tag == "hitme") // checks if the hit game object has the tag "hitme"
                {
                    Debug.Log("delete this now"); // adds one to the hitmarkers variable and destroys the hit object
                    door.hitmarkers++;
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
    void lineDisable() //disables the line and particle system
    {
        line.enabled = false;
        laserhit.gameObject.SetActive(false);
    }
}
