using UnityEngine;
using MiniIT.ENUMS;

namespace MiniIT.AUDIO
{
    public class AudioSources : MonoBehaviour
    {
        public static AudioSources Instance { get; private set; } = null;

        [field: SerializeField]
        public AudioSource         Music { get; private set; } = null;

        [field: SerializeField]
        public AudioSource         Sound { get; private set; } = null;

        [field: SerializeField]
        public AudioSource         UI { get; private set; } = null;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance == this)
            {
                Destroy(gameObject);
            }

            DontDestroyOnLoad(gameObject);
        }

        public AudioSource GetSource(TypeAudioSource typeSource)
        {
            AudioSource audioSource;

            switch (typeSource)
            {
                case TypeAudioSource.Sound:
                    audioSource = Sound;
                    break;

                case TypeAudioSource.UI:
                    audioSource = UI;
                    break;

                case TypeAudioSource.Music:
                    audioSource = Music;
                    break;

                default:
                    audioSource = Sound;
                    break;
            }

            return audioSource;
        }
    }
}