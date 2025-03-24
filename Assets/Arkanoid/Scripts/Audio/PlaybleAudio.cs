using UnityEngine;
using Zenject;

public class PlaybleAudio : MonoBehaviour
{
    [SerializeField]
    private AudioClip   clip = null;

    [Inject]
    private AudioSource source = null;

    public void PlayOneShot()
    {
        source.PlayOneShot(clip);
    }
}