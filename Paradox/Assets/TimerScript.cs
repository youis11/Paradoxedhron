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


    //Create displayed timer
    Text text;

    void Awake()
    {
        //Load Text class
        text = GetComponentInChildren<Text>();
        DontDestroyOnLoad(this.gameObject);

        //Reset the timer
        //timer = 0f;

    }

    void Update()
    {
        //Start the timer and keep it going
        if (startTimer)
            timer -= Time.deltaTime;

        //Write out the timer on the screen
        text.text = "" + timer.ToString();

        Scene scene = SceneManager.GetActiveScene();

        //if (scene.name == "Level0")
        //{
        //    text.text = timer.ToString("F1") + " Points";
        //}
    }

}