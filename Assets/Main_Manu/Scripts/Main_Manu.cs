using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Manu : MonoBehaviour{

    public string Game;
    public string Opcoes;
    public string Creditos;
    public string Voltar;

    public void PlayGameLevel()
    {
        Application.LoadLevel(Game);
    }

    public void PlaySettingsScene()
    {
        Application.LoadLevel(Opcoes);
    }

    public void PlayCreditsScene()
    {
        Application.LoadLevel(Creditos);
    }

    public void Return()
    {
        Application.LoadLevel(Voltar);
    }
}
