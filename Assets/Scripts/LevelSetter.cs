using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSetter : MonoBehaviour
{
    [SerializeField] AudioPreset audio;
    bool resetScore;

    private void OnEnable()
    {
        //SceneAudioManager.PlayPreset(audio);
        StartCoroutine(setValues());
    }

    IEnumerator setValues()
    {
        yield return new WaitForSeconds(0.5f);
        SceneAudioManager.PlayPreset(audio);
    }

    public void Audio(float value)
    {
        AudioListener.volume = value;
    }

}
