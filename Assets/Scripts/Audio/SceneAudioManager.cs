using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SceneAudioManager : MonoBehaviour
    {
        static AudioMixer mixer;
        static AudioSource source;

        void Start()
        {
            if (!source)
            {
                source = GetComponent<AudioSource>();
                mixer = source.outputAudioMixerGroup.audioMixer;
                StartCoroutine(StartFade(2, 1));
            }
        }

        public static void PlayPreset(AudioPreset i)
        {
            i.SetAudioSource(mixer);
        }

        public static IEnumerator StartFade(float duration, float targetVolume)
        {
            float currentTime = 0;
            float start = source.volume;
            while (currentTime < duration)
            {
                currentTime += Time.deltaTime;
                source.volume = Mathf.Lerp(start, targetVolume, currentTime / duration);
                yield return null;
            }
            yield break;
        }
    }
}
