using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
    {
    /// <summary>
    /// all the audio objects and a singelton instance
    /// </summary>
    private static AudioManager _instance;
    public AudioSource Jump;
    public AudioSource Score;
    public AudioSource Death;
    public AudioSource menuMusic;
    public AudioSource gameMusic;
    public AudioSource Hit;
    public AudioSource end;

    /// <summary>
    /// this creates a singelton instance 
    /// </summary>
    public static AudioManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<AudioManager>();
            }

            return _instance;
        }
    }
    void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
