using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinEnding : MonoBehaviour
{
    public AudioSource music;
    public AudioClip winning_music;
    public AudioSource kat_ending;

    private int loopTimes;

    void Start()
    {
        music.PlayOneShot(winning_music, 0.8f);
        loopTimes = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!music.isPlaying)
        {
            loopTimes++;
            if(loopTimes <= 1)
            {
                music.PlayOneShot(winning_music, 0.8f);
            }
            if(loopTimes >= 2)
            {
                Application.Quit();
            }
        }
    }
}
