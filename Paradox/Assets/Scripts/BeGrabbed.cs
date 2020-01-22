using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGrabbed : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;
    public LayerMask tubeEndMask;
    public LayerMask wallMask;

    private void OnTriggerStay(Collider other)
    {
        if (!isGrabbed && other.gameObject.CompareTag("GrabTag"))
        {
            Debug.Log("entered collision");
            Movement player = other.gameObject.GetComponentInParent<Movement>();
            if (player.grabbing)
            {
                Vector3 origin = player.cameraTransform.position;
                Vector3 dir = player.cameraTransform.forward;
                float maxDistance = Vector3.Distance(transform.position, player.cameraTransform.position);
                if (!Physics.Raycast(origin, dir, maxDistance, wallMask))
                {
                    Debug.Log("grabbing collision");
                    player.grabbed = gameObject;
                    isGrabbed = true;
                    Destroy(GetComponent<Rigidbody>());
                    transform.SetParent(player.transform.Find("Camera"));
                    GetComponent<ParadaxPolyhedron>().ChangeCollider(other.GetComponentInParent<PlayerPolyhedron>().PlayerShape);
                }
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
