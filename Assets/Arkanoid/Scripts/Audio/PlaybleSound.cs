using MiniIT.Enums;
using UnityEngine;

public class PlaybleSound : MonoBehaviour
{
    [SerializeField]
    private TypeAudioSource typeSource = TypeAudioSource.Sound;

    [SerializeField]
    private AudioClipPreset[] clips = null;

    public void Play()
    {
        int clip = Random.Range(0, clips.Length);

        float pitch = Random.Range(clips[clip].Pitch.Min, clips[clip].Pitch.Max);

        SetSource(typeSource, pitch, clips[clip].Clip);
    }

    private void SetSource(TypeAudioSource typeAudioSource, float pitch, AudioClip clip)
    {
        AudioSource audioSource;

        switch (typeAudioSource)
        {
            case TypeAudioSource.Sound:
                audioSource = AudioSources.Instance.Sound;
                break;

            case TypeAudioSource.UI:
                audioSource = AudioSources.Instance.UI;
                break;

            default:
                audioSource = AudioSources.Instance.Sound;
                break;
        }

        audioSource.pitch = pitch;

        audioSource.PlayOneShot(clip);
    }
}

[System.Serializable]
public struct AudioClipPreset
{
    public AudioClip Clip;

    public MinMax    Pitch;
}