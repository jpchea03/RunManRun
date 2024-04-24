using UnityEngine;
using UnityEngine.UI;

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
    public AudioClip clickSound; // New field for the click sound

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
        musicSource.loop = true;
        musicSource.Play();
    }

    // Method to play the click sound
    public void PlayClickSound()
    {
        SFXSource.PlayOneShot(clickSound);
    }
}