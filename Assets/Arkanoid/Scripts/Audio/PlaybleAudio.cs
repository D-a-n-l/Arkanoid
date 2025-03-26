using UnityEngine;
using MiniIT.ENUMS;
using MiniIT.PRESETS;
using NaughtyAttributes;

namespace MiniIT.AUDIO
{
    public class PlaybleAudio : MonoBehaviour
    {
        [SerializeField]
        private TypeAudioSource   typeSource = TypeAudioSource.Sound;

        [ShowIf(nameof(typeSource), TypeAudioSource.Music)]
        [SerializeField]
        private bool              isPlayLoopStart = true;

        [SerializeField]
        private AudioClipPreset[] clips = null;

        private AudioSource       source = null;

        private void Start()
        {
            source = AudioSources.GetSource(typeSource);

            if (isPlayLoopStart == true)
            {
                PlayLoop();
            }
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

            while (clips[clip].Clip == source.clip)
            {
                clip = Random.Range(0, clips.Length);
            }

            source.pitch = pitch;

            source.clip = clips[clip].Clip;

            source.Play();

            Invoke(nameof(PlayLoop), source.clip.length);
        }
    }
}