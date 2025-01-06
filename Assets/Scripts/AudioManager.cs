using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    [SerializeField]
    private AudioSource audioSource;
    [SerializeField]
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        PlayAudio();
    }
    public void PlayAudio()
    {
        audioSource.loop = true;
        audioSource.Play();
    }
    public void StopAudio()
    {
        audioSource.Stop();
    }
}
