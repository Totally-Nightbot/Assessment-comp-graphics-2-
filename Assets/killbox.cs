using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class killbox : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        var ragdoller =
        other.gameObject.GetComponent<Ragdoll>();
        if (ragdoller != null)
        {
            ragdoller.RagdollOn();
        }
    }
}
