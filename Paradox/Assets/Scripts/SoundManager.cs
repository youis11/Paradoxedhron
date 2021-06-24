using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip jump, grab, reset, wave, dance;

    static AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        jump = Resources.Load<AudioClip>("jumpSfx");
        grab = Resources.Load<AudioClip>("grabSfx");
        reset = Resources.Load<AudioClip>("resetSfx");
        wave = Resources.Load<AudioClip>("waveSfx");
        dance = Resources.Load<AudioClip>("danceeSfx");

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
            case "wave":
                audioSource.PlayOneShot(wave,0.5f);
                break;
            case "dance":
                audioSource.PlayOneShot(dance, 0.1f);
                break;
        }
    }
}
