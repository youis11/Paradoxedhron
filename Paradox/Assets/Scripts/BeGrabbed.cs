using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeGrabbed : MonoBehaviour
{
    [HideInInspector]
    public bool isGrabbed = false;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (!isGrabbed && other.gameObject.CompareTag("GrabTag"))
        {
            if (other.gameObject.GetComponentInParent<Movement>().grabbing)
            {
                Movement movement = other.gameObject.GetComponentInParent<Movement>();
                movement.grabbed = gameObject;
                isGrabbed = true;
            }
        }
    }
}
