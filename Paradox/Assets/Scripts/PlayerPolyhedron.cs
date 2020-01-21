using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shape
{
    sphere,
    box
};

public class PlayerPolyhedron : MonoBehaviour
{
    private Shape playerPolyhedron;
    private Camera playerCamera;

    private void Start()
    {
        playerCamera = GetComponentInChildren<Camera>();
    }

    public Shape PlayerPolyhedron
    {
        set
        {
            playerPolyhedron = value;
            if (playerPolyhedron == Shape.box)
            {

            }
            else if (playerPolyhedron == Shape.sphere)
            {

            }
        }
    }

}

