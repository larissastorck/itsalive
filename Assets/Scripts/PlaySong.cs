using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(AudioSource))]
public class PlaySong : MonoBehaviour
{

    static AudioSource audioData;
    // Start is called before the first frame update

    void Awake()
    {
        if (audioData == null)
        {
            audioData = GetComponent<AudioSource>();
            DontDestroyOnLoad(audioData.gameObject);
           
        }
        else
        {
            //If a Singleton already exists and you find
            //another reference in scene, destroy it!
            if (this != audioData)
                Destroy(this.gameObject);
        }
    }



    void Start()
    {
       
        audioData.Play(0);
    }

    public void StopMusic()
    {
        audioData.Stop();
    }

}
