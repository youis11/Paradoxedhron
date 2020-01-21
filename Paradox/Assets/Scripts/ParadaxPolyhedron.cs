using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParadaxPolyhedron : MonoBehaviour
{
    string player1Tag = "player1";
    string player2Tag = "player2";
    BoxCollider boxCollider;
    SphereCollider sphereCollider;

    bool startInverted = false;

    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        sphereCollider = GetComponent<SphereCollider>();

        if (startInverted)
        {
            boxCollider.enabled = true;
            sphereCollider.enabled = false;
        }
        else
        {
            boxCollider.enabled = false;
            sphereCollider.enabled = true;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(player1Tag))
        {
            ChangeCollider(collision.gameObject.GetComponent<PlayerPolyhedron>().playerPolyhedron);
        }
        else if (collision.gameObject.CompareTag(player2Tag))
        {
            ChangeCollider(collision.gameObject.GetComponent<PlayerPolyhedron>().playerPolyhedron);
        }
    }

    private void ChangeCollider(Shape shape)
    {
        if (shape == Shape.box)
        {
            if (!boxCollider.enabled)
            {
                //Play sfx change shape
                boxCollider.enabled = true;
                sphereCollider.enabled = false;
            }
        }
        else if (shape == Shape.sphere)
        {
            if (!sphereCollider.enabled)
            {
                //Play sfx change round
                sphereCollider.enabled = true;
                boxCollider.enabled = false;
            }
        }
    }
}
