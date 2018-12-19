using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    public AudioClip mainMenuAudio;      //Cria um slot para adicionar nosso audio
    public AudioClip _Audio;      //Cria um slot para adicionar nosso audio


    public Texture _titleBackground; //image do menu inicial

    public int mainMenuButtonWidth = 120; //Definindo a largura do botao
    public int mainMenuButtonHeight = 30; //Definindo a altura do botao

    public GUISkin mainMenuSkin;           //Cria um slot para adicionar nossa skin


	// Use this for initialization
	void Start () {
        MusicManager();
    }

    void MusicManager()
    {
        GetComponent<AudioSource>().clip = mainMenuAudio;   //Inicia com a musica que atribuimos
        GetComponent<AudioSource>().Play();                 //toca a musica
        GetComponent<AudioSource>().loop = true;            //toca a musica varias vezes
    }

    void OnGUI()
    {
        GUI.skin = mainMenuSkin;
        

        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), _titleBackground);
        //Debug.Log(Screen.width + " " + Screen.height);

        if (GUI.Button(new Rect(Screen.width / 2 - (mainMenuButtonWidth / 2), Screen.height / 1.29f, mainMenuButtonWidth, mainMenuButtonHeight), "História"))
        {
            GetComponent<AudioSource>().PlayOneShot(_Audio);               //toca a musica de start uma vez só
            SceneManager.LoadScene("History"); //abre a primeira cena
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (mainMenuButtonWidth/2), Screen.height /1.2f, mainMenuButtonWidth, mainMenuButtonHeight), "Iniciar"))
        {
            GetComponent<AudioSource>().PlayOneShot(_Audio);               //toca a musica de start uma vez só
            TimeCounter.timer = 120f;
            SceneManager.LoadScene("SampleScene"); //abre a primeira cena
        }

        if (GUI.Button(new Rect(Screen.width / 2 - (mainMenuButtonWidth / 2), Screen.height / 1.12f, mainMenuButtonWidth, mainMenuButtonHeight), "Sair"))
        {
            GetComponent<AudioSource>().PlayOneShot(_Audio);     //toca a musica de sair uma vez só
            //_quitAudio.
            Application.Quit();
        }
    }

    // Update is called once per frame

}
