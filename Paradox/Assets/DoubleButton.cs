using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton : MonoBehaviour
{
    public bool isSphere = true;
    public GameObject barrier = null;
    bool down = false;
    float posDown = 0;
    public float velocity = 1;
    // Start is called before the first frame update
    void Start()
    {
        transform.Find("SphereButtonMesh").gameObject.SetActive(isSphere);
        transform.Find("CubeButtonMesh").gameObject.SetActive(!isSphere);
    }

    // Update is called once per frame
    void Update()
    {
        if (down)
        {
            if (posDown <= -4)
            {
                posDown = -4;
                barrier.transform.localPosition = new Vector3(0, posDown, 0);
            }
            else
            {
                posDown -= velocity * Time.deltaTime;
                barrier.transform.localPosition = new Vector3(0, posDown, 0);
            }
        }
        else
        {
            print(posDown);
            if (posDown >= 0)
            {
                posDown = 0;
                barrier.transform.localPosition = new Vector3(0, posDown, 0);
            }
            else
            {
                posDown += velocity * Time.deltaTime;
                barrier.transform.localPosition = new Vector3(0, posDown, 0);
            }
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (collider.gameObject.CompareTag("ParadoxObject"))
        {
            if (collider.GetComponent<BoxCollider>().enabled)
            {
                if (!isSphere)
                {
                    down = true;
                }
            }
            else
            {
                if (isSphere)
                {
                    down = true;
                }
            }
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.CompareTag("ParadoxObject"))
        {
            if (collider.GetComponent<BoxCollider>().enabled)
            {
                if (!isSphere)
                {
                    down = false;
                }
            }
            else
            {
                if (isSphere)
                {
                    down = false;
                }
            }
        }
    }
}
