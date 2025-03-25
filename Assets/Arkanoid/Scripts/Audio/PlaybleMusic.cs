using UnityEngine;

public class PlaybleMusic : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] clips = new AudioClip[1];

    private void Start()
    {
        PlayLoop();
    }

    private void PlayLoop()
    {
        int clip = Random.Range(0, clips.Length);

        while (clips[clip] == AudioSources.Instance.Music.clip)
        {
            clip = Random.Range(0, clips.Length);
        }

        AudioSources.Instance.Music.clip = clips[clip];

        AudioSources.Instance.Music.Play();

        Invoke(nameof(PlayLoop), AudioSources.Instance.Music.clip.length);
    }
}