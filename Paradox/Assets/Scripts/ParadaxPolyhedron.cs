using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadaxPolyhedron : MonoBehaviour
{
    string player1Tag = "player_1";
    string player2Tag = "player_2";
    BoxCollider boxCollider;
    SphereCollider sphereCollider;

    bool startInverted = false;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();

        if (startInverted)
        {
            boxCollider.enabled = false;
            sphereCollider.enabled = true;
        }
        else
        {
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(player1Tag))
        {
            ChangeCollider(collision.gameObject.GetComponent<PlayerPolyhedron>().PlayerShape);
        }
        else if (collision.gameObject.CompareTag(player2Tag))
        {
            ChangeCollider(collision.gameObject.GetComponent<PlayerPolyhedron>().PlayerShape);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        GetComponentInParent<Rigidbody>().mass = 1;
    }

    public void ChangeCollider(Shape shape)
    {
        if (shape == Shape.box)
        {
            GetComponentInParent<Rigidbody>().mass = 999999999;
            if (!boxCollider.enabled)
            {
                //Play sfx change shape
                boxCollider.enabled = true;
                sphereCollider.enabled = false;
            }
        }
        else if (shape == Shape.sphere)
        {
            GetComponentInParent<Rigidbody>().mass = 1;
            if (!sphereCollider.enabled)
            {
                //Play sfx change round
                sphereCollider.enabled = true;
                boxCollider.enabled = false;
            }
        }
    }
}
