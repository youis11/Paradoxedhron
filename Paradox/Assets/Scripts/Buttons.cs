using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject camera;
    public GameObject main_menu;
    public GameObject options_menu;

    public void GoToOptions()
    {
        StartCoroutine(camera_to_options());
        main_menu.SetActive(false);
        options_menu.SetActive(true);
    }

    IEnumerator camera_to_options()
    {
        float initial_posX = camera.transform.position.x;
        float initial_rotY = camera.transform.rotation.eulerAngles.y;
        for (; ; )
        {
            float percentage = (camera.transform.position.x - initial_posX) / (140 - initial_posX);
            float percentageRot = (camera.transform.rotation.eulerAngles.y - initial_rotY) / (-45 - initial_rotY);
            camera.transform.position = new Vector3(Mathf.Lerp(initial_posX, 140, percentage), camera.transform.position.y, camera.transform.position.z);
            camera.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(initial_rotY, -45, percentageRot), 0);
            if (camera.transform.position.x == 300 && camera.transform.rotation.eulerAngles.y == -45) 
            {
                StartCoroutine(camera_to_options2());
                break;
            }
            yield return new WaitForFixedUpdate();
        }
    }

    IEnumerator camera_to_options2()
    {
        float initial_pos_z = camera.transform.position.z;
        for (; ; )
        {
            float percentage = (0 - camera.transform.position.z) / initial_pos_z;
            camera.transform.position = new Vector3(camera.transform.position.x, camera.transform.position.y, Mathf.Lerp(camera.transform.position.z, 0, percentage));
            camera.transform.rotation = Quaternion.Euler(0, Mathf.Lerp(camera.transform.rotation.eulerAngles.y, -90, 1), 0);
            if (camera.transform.position.z == 0 && camera.transform.rotation.eulerAngles.y == -90)
            {
                break;
            }
            yield return 0;
        }
    }
}
