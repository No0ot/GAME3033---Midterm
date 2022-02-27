using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    public AudioClip mainMenuMusic;
    public AudioClip gameplayMusic;
    public AudioClip jumpSound;
    public AudioClip pickupSound;
    public AudioClip dropSound;

    public AudioSource musicSource;
    public AudioSource soundSource;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;

       
    }

    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu")
        {
            musicSource.clip = mainMenuMusic;
            musicSource.Play();
        }
        else if (SceneManager.GetActiveScene().name == "GameplayScene")
        {
            musicSource.clip = gameplayMusic;
            musicSource.Play();
        }
    }

    public void PlayJump()
    {
        soundSource.clip = jumpSound;
        soundSource.Play();
    }
    public void PlayPickup()
    {
        soundSource.clip = pickupSound;
        soundSource.Play();
    }

    public void PlayDrop()
    {
        soundSource.clip = dropSound;
        soundSource.Play();
    }
}
