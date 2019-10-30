using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGameSong : MonoBehaviour
{
    AudioSource audioData;

    GameObject audioMenu;
    // Start is called before the first frame update

    private void Awake()
    {
        audioMenu = GameObject.FindGameObjectWithTag("MenuMusic");
        audioMenu.GetComponent<PlaySong>().StopMusic();
    }

    void Start()
    {
        audioData = GetComponent<AudioSource>();
        audioData.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
