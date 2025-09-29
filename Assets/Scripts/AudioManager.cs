using System;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("-------- Audio Source --------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    [Header("-------- Audio Clip --------")]
    public AudioClip background;
    public AudioClip enemyKill;
    public AudioClip coinCollect;
    public AudioClip exit;
    public AudioClip finishGame;
    public AudioClip gameOver;
    public AudioClip bouncing;


    private void Awake()
    {
        int numberofAudioManager = FindObjectsByType<AudioManager>(FindObjectsSortMode.None).Length;

        if (numberofAudioManager > 1)
        {
            Destroy(gameObject); // fazlaysa yok et
        }
        else
        {
            DontDestroyOnLoad(gameObject); // tek olanı koru
        }
    }


    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }
}
