using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using XInputDotNetPure;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;
    public GameObject introPanel;

    TimerScript timerSc;

    GamePadState state;

    // Update is called once per frame
    public float msec = 60f;

    void Start()
    {
        Scene scene = SceneManager.GetActiveScene();

        if (scene.name == "Level0")
        {
            StartCoroutine(LateCall());
        }

        timerSc = GameObject.Find("TimeManager").GetComponent<TimerScript>();
    }

    IEnumerator LateCall()
    {

        yield return new WaitForSeconds(msec);

        introPanel.SetActive(false);
        timerSc.startTimer = true;
        //Do Function here...
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    private void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }
}
