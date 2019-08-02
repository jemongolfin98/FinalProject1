using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffects : MonoBehaviour
{
    public AudioSource levelMusic;
    public AudioSource winMusic;
    public AudioSource loseMusic;

    public bool levelSong = true;
    public bool winSong = false;
    public bool loseSong = false;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LevelMusic()
    {
        levelSong = true;
        winSong = false;
        loseSong = false;
        levelMusic.Play();
    }

    public void WinMusic()
    {
        if(levelMusic.isPlaying)
        
            levelSong = false;
        {
            levelMusic.Stop();
            winMusic.Play();
            winSong = true;
        }
        
    }

    public void LoseMusic()
    {
        if (levelMusic.isPlaying)
            levelSong = false;

        {
            levelMusic.Stop();
            loseMusic.Play();
            loseSong = true;
        }
    }
}
