using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereTube : MonoBehaviour
{
    [Tooltip("Ordered")]
    public Transform[] points;
    private float minDist = 0.5f;
    private float movementSpeed = 20f;

    public IEnumerator Move(Transform sphere)
    {
        sphere.GetComponent<SphereCollider>().enabled = false;
        sphere.GetComponent<Rigidbody>().useGravity = false;
        sphere.GetComponent<Rigidbody>().velocity = Vector3.zero;
        bool reversed = false;
        //1- See in which end we are
        if (Vector3.Distance(points[0].position, sphere.position)
            < Vector3.Distance(points[points.Length - 1].position, sphere.position))
        {
            reversed = false;
        }
        else
        {
            reversed = true;
        }
        //2- Move
        if (reversed)
        {
            for (int i = 0; i < points.Length - 1;)
            {
                Vector3 movement = (points[i].position - sphere.position).normalized * movementSpeed * Time.deltaTime;
                sphere.position += movement;
                if (Vector3.Distance(sphere.position, points[i].position) < minDist)
                {
                    i++;
                }
                yield return null;
            }
        }
        else
        {
            for (int i = points.Length - 1; i > 0;)
            {
                Vector3 movement = (points[i].position - sphere.position).normalized * movementSpeed * Time.deltaTime;
                sphere.position += movement;
                if (Vector3.Distance(sphere.position, points[i].position) < minDist)
                {
                    i--;
                }
                yield return null;
            }
        }
        sphere.GetComponent<SphereCollider>().enabled = true;
        sphere.GetComponent<Rigidbody>().useGravity = true;
    }
}
