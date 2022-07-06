using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class AudioPreset
{
    [Range(0.1f, 2)]
    public float volume;
    [Range(0.1f, 2.5f)]
    public float pitch;
    [Range(-10000.0f, 0)]
    public float reverb;

    public void SetAudioSource(AudioMixer audioS)
    {
        audioS.SetFloat("Pitch", this.pitch);
        audioS.SetFloat("Reverb", this.reverb);
    }
}
