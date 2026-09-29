using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio Clips")]
    public AudioClip gameMusic;
    public AudioClip jumpSound;
    public AudioClip gameEndSound;

    private AudioSource musicSource;
    private AudioSource soundSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        //audiosourcet
        musicSource = gameObject.AddComponent<AudioSource>();
        soundSource = gameObject.AddComponent<AudioSource>();

        musicSource.loop = true;
        musicSource.playOnAwake = false;
        soundSource.playOnAwake = false;
    }

    private void Start()
    {
        PlayMusic();
    }

    public void PlayMusic()
    {
        if (gameMusic != null)
        {
            musicSource.clip = gameMusic;
            musicSource.Play();
        }
    }

    public void PlayJumpSound()
    {
        if (jumpSound != null)
        {
            soundSource.PlayOneShot(jumpSound);
        }
    }

    public void PlayGameEndSound()
    {
        if (gameEndSound != null)
        {
            musicSource.Stop();
            soundSource.PlayOneShot(gameEndSound);
        }
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }
}