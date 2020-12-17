using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//PURPOSE: To change the volume of the music in the options panel 
//USAGE: put this script on the audio source, then on the slider where it says On Value Changed in inspector, set it to the volume function
public class MusicManager : MonoBehaviour
{
    public AudioSource backgroundMusic;
    public float backgroundVol;

    // Start is called before the first frame update
    void Start()
    {
        backgroundMusic = GetComponent<AudioSource>();  // grab the audio source 
    }

    // Update is called once per frame
    void Update()
    {
        //make it so the float can control the audio source vol 
        backgroundMusic.volume = backgroundVol;
        
    }

    public void SetVolume(float vol) // function activated by slider
    {
        backgroundVol = vol;
    }
}
