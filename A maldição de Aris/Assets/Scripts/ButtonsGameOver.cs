using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsGameOver : MonoBehaviour {

    public AudioClip gameOverAudio;      //Cria um slot para adicionar nosso audio
    public AudioClip _audioButton;

    public Texture _gameOverBackground; //image do menu inicial

    public int mainMenuButtonWidth = 120; //Definindo a largura do botao
    public int mainMenuButtonHeight = 30; //Definindo a altura do botao

    public GUISkin gameOverSkin;

    // Use this for initialization
    void Start ()
    {
        MusicManager();
    }

    void MusicManager()
    {
        //GetComponent<AudioSource>().clip = gameOverAudio;   //Inicia com a musica que atribuimos
        GetComponent<AudioSource>().PlayOneShot(gameOverAudio);                 //toca a musica
        //GetComponent<AudioSource>().loop = true;            //toca a musica varias vezes
    }

    // Update is called once per frame
    void OnGUI()
    {
        GUI.skin = gameOverSkin;


        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _gameOverBackground);

        if (GUI.Button(new Rect(Screen.width / 2 - (mainMenuButtonWidth / 2), Screen.height / 1.2f, mainMenuButtonWidth, mainMenuButtonHeight), "Voltar"))
        {
            GetComponent<AudioSource>().PlayOneShot(_audioButton);               //toca a musica de start uma vez só
            SceneManager.LoadScene("MainMenu"); //abre a primeira cena
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (mainMenuButtonWidth / 2), Screen.height / 1.12f, mainMenuButtonWidth, mainMenuButtonHeight), "Sair"))
        {
            GetComponent<AudioSource>().PlayOneShot(_audioButton);     //toca a musica de sair uma vez só
            Application.Quit();
        }
    }



}
