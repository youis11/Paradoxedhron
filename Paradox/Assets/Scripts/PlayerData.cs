using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class PlayerData
{
    public string level;

    // Start is called before the first frame update
    public PlayerData ()
    {
        level = SceneManager.GetActiveScene().name;
    }
}
