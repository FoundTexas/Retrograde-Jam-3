using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Audio
{
    [RequireComponent(typeof(AudioSource))]
    public class SceneAudioManager : MonoBehaviour
    {
        [SerializeField] List<AudioPreset> Levelspresets;

        AudioMixer mixer;
        static AudioSource source;

        void Start()
        {
            source = GetComponent<AudioSource>();
            mixer = source.outputAudioMixerGroup.audioMixer;
            StartCoroutine(StartFade(2, 1));
        }

        void Update()
        {

        }

        public void PlayPreset(int i)
        {
            Levelspresets[i].SetAudioSource(mixer);
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
