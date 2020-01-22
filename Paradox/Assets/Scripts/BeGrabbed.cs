using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGrabbed : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;

    private void OnTriggerStay(Collider other)
    {
        if (!isGrabbed && other.gameObject.CompareTag("GrabTag"))
        {
            if (other.gameObject.GetComponentInParent<Movement>().grabbing)
            {
                Movement movement = other.gameObject.GetComponentInParent<Movement>();
                movement.grabbed = gameObject;
                isGrabbed = true;
                GetComponent<ParadaxPolyhedron>().ChangeCollider(other.GetComponent<PlayerPolyhedron>().PlayerShape); 
            }
        }
    }
}
