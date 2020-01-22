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

    private void OnCollisionEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("player_1") || collision.gameObject.CompareTag("player_2")) 
        {
            PlayerPolyhedron poly = collision.gameObject.GetComponent<PlayerPolyhedron>();
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
