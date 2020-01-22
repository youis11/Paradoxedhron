using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XInputDotNetPure;
using UnityEngine.SceneManagement;
public class skipVictory : MonoBehaviour
{
    float time;
    GamePadState state;
    public PlayerIndex playerIndex;
    // Start is called before the first frame update
    void Start()
    {
        time = Time.realtimeSinceStartup;
        
    }

    // Update is called once per frame
    void Update()
    {
        state = GamePad.GetState(playerIndex);
        if ((time + 5 < Time.realtimeSinceStartup) && state.Buttons.A == ButtonState.Pressed)
        {
            SceneManager.LoadScene("UI");
        }
    }
}
