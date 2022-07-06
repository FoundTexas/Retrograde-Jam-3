using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXManager : MonoBehaviour
{
    AudioSource audios;
    // Start is called before the first frame update
    void Start()
    {
        audios = GetComponent<AudioSource>();
    }

    public void playSpecific(AudioClip audio)
    {
        audios.PlayOneShot(audio);
    }
}
