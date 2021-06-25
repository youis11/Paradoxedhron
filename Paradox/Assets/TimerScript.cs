using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{
    //Create timer
    public static float timer = 24f * 60f;

    //Bool
    public bool startTimer = false;
    static bool firstTime = false;

    //Create displayed timer
    Text text;

    void Awake()
    {
        if(!firstTime)
        {
            //Load Text class
            text = GetComponentInChildren<Text>();
            DontDestroyOnLoad(this.gameObject);

            SceneManager.sceneLoaded += isLevel0;

            firstTime = true;
        }
        else
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

    }

    void Update()
    {
        //Start the timer and keep it going
        if (startTimer)
            timer -= Time.deltaTime;

        //Write out the timer on the screen
        text.text = "" + timer.ToString();

        Scene scene = SceneManager.GetActiveScene();

        if (timer <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene("Level0");
            timer = 24f * 60f;
        }

        if (scene.name == "MainMenu" || scene.name == "Winning")
        {
            text.text = "";
        }
    }

    void isLevel0(Scene scene, LoadSceneMode loadScene)
    {
        if (scene.buildIndex == 1)
        {
            timer = 24f * 60f;
        }
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= isLevel0;
    }

}