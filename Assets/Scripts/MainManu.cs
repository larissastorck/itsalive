using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManu : MonoBehaviour{

    public string Game;
    public string Opcoes;
    public string Creditos;
    public string Voltar;

    AudioSource audioData;


    private void Awake()
    {
        audioData = GetComponent<AudioSource>();
    }

    public void PlayGameLevel()
    {
        audioData.Play();
        Application.LoadLevel(Game);
    }

    public void PlaySettingsScene()
    {
        Application.LoadLevel(Opcoes);
    }

    public void PlayCreditsScene()
    {
        audioData.Play();
        Application.LoadLevel(Creditos);
    }

    public void Return()
    {
        audioData.Play();
        Application.LoadLevel(Voltar);
    }
}
