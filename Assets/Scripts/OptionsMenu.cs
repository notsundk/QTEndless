using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    public AudioMixer Mixer;
    public Slider Slide;
    public bool mute = false;

    public void ChangeVolume()
    {
        Mixer.SetFloat("Volume", Slide.value);
    }

    public void Mute()
    {
        mute = !mute;
        switch (mute)
        {
            case true:
                Mixer.SetFloat("Volume", -80f);
                break;
            case false: 
                Mixer.SetFloat("Volume", Slide.value);
                break;
            default:
                break;
        }
    }
}
