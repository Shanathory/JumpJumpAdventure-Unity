using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  A cada objeto que le agreguemos este escript, le creara un
 *  AudioSurce automaticamente.
 */
[RequireComponent(typeof(AudioSource))] 

public class AudioManager : MonoBehaviour
{
    public static AudioManager sharedInstace { get; private set; }
    private AudioSource audioSource;

    private void Awake()
    {
        if (sharedInstace == null)
        {
            sharedInstace = this;
        }
        else
        {
            Debug.Log("CUIDADO. MAS DE UN AUDIOMANAGER EN ESCENA.");
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void ReproducirSonido(AudioClip audio)
    {
        audioSource.PlayOneShot(audio);
    }
}
