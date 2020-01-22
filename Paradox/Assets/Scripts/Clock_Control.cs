using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clock_Control : MonoBehaviour
{
    public float degrees;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y , transform.rotation.eulerAngles.z - degrees * Time.deltaTime);
    }
}
