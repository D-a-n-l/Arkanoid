using UnityEngine;
using MiniIT.ENUMS;
using MiniIT.PRESETS;
using UnityEngine.Audio;

namespace MiniIT.AUDIO
{
    public class PlaybleSound : MonoBehaviour
    {
        [SerializeField]
        private TypeAudioSource   typeSource = TypeAudioSource.Sound;

        [SerializeField]
        private AudioClipPreset[] clips = null;

        private AudioSource       source;

        private void Awake()
        {
            source = GetSource();
        }

        public void Play()
        {
            int clip = Random.Range(0, clips.Length);

            float pitch = Random.Range(clips[clip].Pitch.Min, clips[clip].Pitch.Max);

            source.pitch = pitch;

            source.PlayOneShot(clips[clip].Clip);
        }

        public void PlayLoop()
        {
            int clip = Random.Range(0, clips.Length);

            float pitch = Random.Range(clips[clip].Pitch.Min, clips[clip].Pitch.Max);

            while (clips[clip].Clip == AudioSources.Instance.Music.clip)
            {
                clip = Random.Range(0, clips.Length);
            }

            source.pitch = pitch;

            source.clip = clips[clip].Clip;

            source.Play();

            Invoke(nameof(PlayLoop), source.clip.length);
        }

        private AudioSource GetSource()
        {
            AudioSource audioSource;

            switch (typeSource)
            {
                case TypeAudioSource.Sound:
                    audioSource = AudioSources.Instance.Sound;
                    break;

                case TypeAudioSource.UI:
                    audioSource = AudioSources.Instance.UI;
                    break;

                case TypeAudioSource.Music:
                    audioSource = AudioSources.Instance.Music;
                    break;

                default:
                    audioSource = AudioSources.Instance.Sound;
                    break;
            }

            return audioSource;
        }
    }
}