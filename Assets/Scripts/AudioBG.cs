using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioBG : MonoBehaviour
{

    //public AudioClip[] audios;
    private AudioSource audio;

    void Start(){
        audio = GetComponent<AudioSource>();
        StartMusic();
    }

    public void StartMusic(){
        //int numAudio = Random.Range(0, 9); 
        //audio.clip = audios[numAudio];
        audio.Play();
    }

    public void StopMusic(){
        audio.Stop();
    }

}
