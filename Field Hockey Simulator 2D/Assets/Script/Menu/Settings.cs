using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixerGroup Mixer;

    public void ToggMusicVolume(bool volume)
    {
        if (volume)
            Mixer.audioMixer.SetFloat("MusicVolume", 0);
        else
        {
            Mixer.audioMixer.SetFloat("MusicVolume", -20);
        }
    }

    public void ToggEffectsVolume(bool volume)
    {
        if (volume)
            Mixer.audioMixer.SetFloat("EffectsVolume", 0);
        else
            Mixer.audioMixer.SetFloat("EffectsVolume", -10);
    }
}
