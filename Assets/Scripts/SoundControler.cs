using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControler : MonoBehaviour
{
    public AudioSource MusicBox;
    public AudioSource Laught;
    public AudioSource PumpkinScream;
    public AudioSource ClownScream;
    public AudioSource JestersScream;
    public AudioSource ButtonClick;

    public void PlayMusicBox(bool Play)
    {
        PlaySound(MusicBox, Play);
    }

    public void PlayJesterLaught(bool Play)
    {
        PlaySound(Laught, Play);
    }

    public void PlayPumpkinScream(bool Play)
    {
        PlaySound(PumpkinScream, Play);
    }

    public void PlayClowScream(bool Play)
    {
        PlaySound(ClownScream, Play);
    }

    public void PlayJesterScream(bool Play)
    {
        PlaySound(JestersScream, Play);
    }

    public void PlayButtonClick(bool Play)
    {
        PlaySound(ButtonClick, Play);
    }
    
    private void PlaySound(AudioSource Audio, bool Play)
    {
        if(Play == true)
        {
            Audio.Play();
        }
        else
        {
            Audio.Stop();
        }
    }
}
