using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartJogo : MonoBehaviour {

    public AudioClip musicaJogoInicio;
    public AudioClip musicaJogoTempoRestante;
    private bool flag1 = true;
    // Use this for initialization
    void Start () {
        MusicManager();
    }

    void MusicManager()
    {
        GetComponent<AudioSource>().clip = musicaJogoInicio;   //Inicia com a musica que atribuimos
        GetComponent<AudioSource>().Play();                 //toca a musica
        GetComponent<AudioSource>().loop = true;            //toca a musica varias vezes
    }

    // Update is called once per frame
    void Update () {
        if ((TimeCounter.timer > 0f) && (TimeCounter.timer < 11f) && (flag1 == true))
        {
            flag1 = false;
            GetComponent<AudioSource>().PlayOneShot(musicaJogoTempoRestante);
        }

        if(TimeCounter.timer == 0f)
        {
            GetComponent<AudioSource>().Stop();
        }
    }

 
}
