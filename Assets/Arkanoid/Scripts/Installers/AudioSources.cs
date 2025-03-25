using UnityEngine;

public class AudioSources : MonoBehaviour
{
    public static AudioSources Instance = null;
    
    [field: SerializeField]
    public AudioSource Music { get; private set; } = null;

    [field: SerializeField]
    public AudioSource Sound { get; private set; } = null;

    [field: SerializeField]
    public AudioSource UI { get; private set; } = null;

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
}