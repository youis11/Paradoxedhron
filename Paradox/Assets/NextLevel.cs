using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    bool player1 = false;
    bool player2 = false;
    public string nextScene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("player_1"))
        {
            player1 = true;
        }
        else if (collision.gameObject.CompareTag("player_2"))
        {
            player2 = true;
        }

        if (player1 && player2)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(nextScene);
        }
    }

    private void OnTriggerExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("player_1"))
        {
            player1 = false;
        }
        else if (collision.gameObject.CompareTag("player_2"))
        {
            player2 = false;
        }
    }
}
