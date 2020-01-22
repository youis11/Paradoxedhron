using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGrabbed : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;
    public LayerMask tubeEndMask;

    private void OnTriggerStay(Collider other)
    {
        if (!isGrabbed && other.gameObject.CompareTag("GrabTag"))
        {
            Debug.Log("entered collision");
            Movement player = other.gameObject.GetComponentInParent<Movement>();
            if (player.grabbing)
            {
                Debug.Log("grabbing collision");
                player.grabbed = gameObject;
                isGrabbed = true;
                GetComponent<ParadaxPolyhedron>().ChangeCollider(other.GetComponentInParent<PlayerPolyhedron>().PlayerShape); 
            }
        }
    }

    public void Release()
    {
        Collider[] touchedColliders = Physics.OverlapSphere(transform.position, 0.5f, tubeEndMask);
        if (touchedColliders.Length > 0)
        {
            SphereTube tube = touchedColliders[0].GetComponentInParent<SphereTube>();
            StartCoroutine(tube.Move(this.transform));
        }
    }
}
