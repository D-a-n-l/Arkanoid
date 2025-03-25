using MiniIT.Enums;
using UnityEngine;
using Zenject;

public class PlaybleSound : MonoBehaviour
{
    [SerializeField]
    private TypeAudioSource typeAudioSource = TypeAudioSource.Sound;

    [SerializeField]
    private AudioClip[] clips = null;

    [SerializeField]
    private float pitch = 1f;

    public void PlayOneShot()
    {
        int clip = Random.Range(0, clips.Length);

        AudioSources.Instance.UI.pitch = pitch;

        AudioSources.Instance.UI.PlayOneShot(clips[clip]);
    }
}