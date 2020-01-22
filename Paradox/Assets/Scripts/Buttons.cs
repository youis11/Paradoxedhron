using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    public GameObject camera;
    public GameObject main_menu;
    public GameObject credits;
    public GameObject options_menu;
    public GameObject cube;
    float anglesAdded = 0;
    float range = 0;
    bool movingOptions = false;
    bool movingOptionsToMainMenu = false;
    bool movingCreditsToMainMenu = false;
    bool movingCredits = false;
    public void GoToOptions()
    {
        range = 0;
        movingOptions = true;
        options_menu.SetActive(true);
        anglesAdded = 0;
    }

    public void OpenWebsite(int number)
    {
        switch (number)
        {
            case 0:
                {
                    Application.OpenURL("https://github.com/youis11");
                    break;
                }
            case 1:
                {
                    Application.OpenURL("https://github.com/OriolCs2");
                    break;
                }
            case 2:
                {
                    Application.OpenURL("https://github.com/VictorSegura99");
                    break;
                }
            case 3:
                {
                    Application.OpenURL("https://github.com/JaumeMontagut");
                    break;
                }
            case 4:
                {
                    Application.OpenURL("https://github.com/optus23");
                    break;
                }
        }
    }

    public void ReturnOptionsToMainMenu()
    {
        range = 0;
        movingOptionsToMainMenu = true;
        main_menu.SetActive(true);
        anglesAdded = 0;
    }

    public void ReturnmainMenuToCredits()
    {
        range = 0;
        movingCredits = true;
        credits.SetActive(true);
        anglesAdded = 0;
    }

    public void GoMainMenu()
    {
        range = 0;
        movingCreditsToMainMenu = true;
        main_menu.SetActive(true);
        anglesAdded = 0;
    }
    private void Update()
    {
        if (movingOptions)
        {
            range += 2 * Time.deltaTime;
            anglesAdded = Mathf.Lerp(0, 90, range);
            cube.transform.localRotation = Quaternion.Euler(cube.transform.localRotation.eulerAngles.x, anglesAdded, cube.transform.localRotation.eulerAngles.z);
            if (anglesAdded >= 90)
            {
                anglesAdded = 90;
                movingOptions = false;
                main_menu.SetActive(false);
            }
        }

        if (movingOptionsToMainMenu)
        {
            range += 2 * Time.deltaTime;
            anglesAdded = Mathf.Lerp(90, 0, range);
            cube.transform.localRotation = Quaternion.Euler(cube.transform.localRotation.eulerAngles.x, anglesAdded, cube.transform.localRotation.eulerAngles.z);
            if (anglesAdded <= 0)
            {
                anglesAdded = 0;
                movingOptionsToMainMenu = false;
                options_menu.SetActive(false);
            }
        }

        if (movingCreditsToMainMenu)
        {
            range += 2 * Time.deltaTime;
            anglesAdded = Mathf.Lerp(-90, 0, range);
            cube.transform.localRotation = Quaternion.Euler(cube.transform.localRotation.eulerAngles.x, anglesAdded, cube.transform.localRotation.eulerAngles.z);
            if (anglesAdded >= 0)
            {
                anglesAdded = 0;
                movingCreditsToMainMenu = false;
                credits.SetActive(false);
            }
        }

        if (movingCredits)
        {
            range += 2 * Time.deltaTime;
            anglesAdded = Mathf.Lerp(0, -90, range);
            cube.transform.localRotation = Quaternion.Euler(cube.transform.localRotation.eulerAngles.x, anglesAdded, cube.transform.localRotation.eulerAngles.z);
            if (anglesAdded <= -90)
            {
                anglesAdded = -90;
                movingCredits = false;
                main_menu.SetActive(false);
            }
        }
    }


}
