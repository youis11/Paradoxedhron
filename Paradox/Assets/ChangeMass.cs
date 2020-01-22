using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMass : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("GrabTag"))
        {
            PlayerPolyhedron poly = collision.gameObject.GetComponentInParent<PlayerPolyhedron>();
            if (poly.PlayerShape == Shape.box)
            {
                GetComponent<Rigidbody>().mass = 999999999999999999;
            }
            else
            {
                GetComponent<Rigidbody>().mass = 1;
            }
        }
    }
}
