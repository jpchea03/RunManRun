using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------Audio Source------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("--------Audio Clip------")]
    public AudioClip background;
    public AudioClip run;
    public AudioClip jump;
    public AudioClip crash;
    public AudioClip GameOver;

    // Ensure only one instance of AudioManager exists
    private static AudioManager instance;

    private void Awake()
    {
        // If an instance already exists, destroy this new instance
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // Set this instance as the singleton instance
        instance = this;

        // Keep this object alive across scene changes
        DontDestroyOnLoad(gameObject);

        // Initialize and play background music
        musicSource.clip = background;
        musicSource.loop = false; // Disable default looping
        musicSource.Play();

        // Start coroutine to check and restart music
        StartCoroutine(CheckAndRestartMusic());
    }

    private IEnumerator CheckAndRestartMusic()
    {
        while (true)
        {
            // Check if the music has stopped playing
            if (!musicSource.isPlaying)
            {
                // Restart the music
                musicSource.Play();
            }

            yield return null;
        }
    }
}
