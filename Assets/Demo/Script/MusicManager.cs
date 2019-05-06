using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] music;

    private AudioSource _audioSource;

    private bool IsPlay;

    private static bool keepFadeIn;
    private static bool keepFadeOut;

    //Singleton
    public static MusicManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }

    private void Start()
    {
        _audioSource = GetComponent<AudioSource>();
        PlayMusic(0);
    }

    public void PlayMusic(int indice)
    {
        _audioSource.clip = music[indice];
        _audioSource.Play();
        StartCoroutine(B(2f, 0.9f, _audioSource));

    }



    public void playSoundListen(int indice)
    {
        if (IsPlay == false)
        {
            IsPlay = true;
            _audioSource.clip = music[indice];
            _audioSource.Play();  
            StartCoroutine(A(_audioSource));
        }
        

    }

    IEnumerator A(AudioSource audio)
    {
    
    
    
    yield return StartCoroutine(B(2f, 0.9f, audio));

        yield return StartCoroutine(C(0.001f, 1f, 5f));

            yield return StartCoroutine(D(2f, 0.9f, audio));
    
    PlayMusic(0);
        IsPlay = false;
        yield return null;

    }



    static IEnumerator B(float speed, float maxVolume, AudioSource audio)
    {
        keepFadeIn = true;
        keepFadeOut = false;
        audio.volume = 0;


        float audioVolumen = audio.volume;

        if (audio.volume == 0)
        {
            while (audio.volume < maxVolume && keepFadeIn)
            {
                audio.volume += Time.deltaTime / speed;
                yield return null;
            }

        }
    }



    static IEnumerator C(float timeInicial, float MaxTime, float delta)
    {
       
        while (timeInicial < MaxTime)
        {
            timeInicial += Time.deltaTime / delta;
            yield return null;
        }

    }


    static IEnumerator D(float speed, float maxVolume, AudioSource audio)
    {
        keepFadeIn = false;
        keepFadeOut = true;

        float audioVolumen = audio.volume;

        while (audio.volume > 0 && keepFadeOut)
        {
            audio.volume -= maxVolume * Time.deltaTime / speed;
            yield return null;
        }
    }

}
