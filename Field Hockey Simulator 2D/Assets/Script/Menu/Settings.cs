using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixerGroup Mixer;
    private bool volumeMusic = false;
    private bool volumeEffects = false;

    public void ToggMusicVolume()
    {
        if (volumeMusic)
        {
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
            volumeMusic = false;
        }
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -80);
            volumeMusic = true;
        }

        PlayerPrefs.SetInt("MusicVolume", volumeMusic ? 1 : 0);
    }

    public void ToggEffectsVolume()   
    {
        if (volumeEffects)
        {
            Mixer.audioMixer.SetFloat("EffectsVolume", 0);
            volumeEffects = false;
        }
        else
        {
            Mixer.audioMixer.SetFloat("EffectsVolume", -80);
            volumeEffects = true;
        }

        PlayerPrefs.SetInt("MusicVolume", volumeEffects ? 1 : 0);
    }
}
