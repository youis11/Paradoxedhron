using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, grab, reset;
    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jumpSfx");
        grab = Resources.Load<AudioClip>("grabSfx");
        reset = Resources.Load<AudioClip>("resetSfx");

        audioSource = GetComponent<AudioSource>();
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "jump":
                audioSource.PlayOneShot(jump);
                break;
            case "grab":
                audioSource.PlayOneShot(grab);
                break;
            case "reset":
                audioSource.PlayOneShot(reset);
                break;
        }
    }
}
