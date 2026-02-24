using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Range(0f, 1f)]
    public float musicVolume = 1f;
    public float sfxVolume = 1f;

    public MusicPlayer musicPlayer; // riferimento al componente MusicPlayer

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Imposta volume musica su entrambi gli AudioSource
    public void SetMusicVolume(float value)
    {
        musicVolume = Mathf.Clamp01(value);

        if (musicPlayer != null)
        {
            if (musicPlayer.introSource != null) musicPlayer.introSource.volume = musicVolume;
            if (musicPlayer.loopSource != null) musicPlayer.loopSource.volume = musicVolume;
        }

        PlayerPrefs.SetFloat("MusicVolume", musicVolume);
    }

    public void SetSFXVolume(float value)
    {
        sfxVolume = Mathf.Clamp01(value);
        PlayerPrefs.SetFloat("SFXVolume", sfxVolume);
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
            AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, sfxVolume);
    }
}