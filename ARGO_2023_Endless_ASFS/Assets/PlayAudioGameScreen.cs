using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioGameScreen : MonoBehaviour
{
    // Start is called before the first frame update

    /// <summary>
    /// this will stop the main menu sound and play the game background sound
    /// </summary>
    void Start()
    {
        AudioManager.Instance.menuMusic.Stop();
        AudioManager.Instance.end.Stop();
        AudioManager.Instance.gameMusic.Play();


    }


}
