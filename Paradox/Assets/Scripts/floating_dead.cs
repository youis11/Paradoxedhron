using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floating_dead : MonoBehaviour
{
    int direction = 1;
    float movement = 0.0f;
    float offset = 0;

    public float min = 0.0f;
    public float max = 0.0f;
    public float time = 0.0f;
    // Update is called once per frame
    void Start()
    {
        movement = (max - min) / time;
    }
    void Update()
    {
        offset = -movement * Time.deltaTime * direction;
        transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, transform.localPosition.z);
        if (transform.localPosition.y <= min)
        {
            //print("AAAAAAAAAAAAAAAAAA");
            direction = -1;
        }

        if (transform.localPosition.y >= max) 
        {
            //print("BBBBBBBBBBBBBBBBBBBBb");
            direction = 1;
        }
    }
}
