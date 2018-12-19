using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyParticleSystem : MonoBehaviour
{
    internal object emission;
    public ParticleSystem particle;
    private bool flag = true;
    public GameObject gameOverMenu;

    // Use this for initialization
    //void Start () {
    //    particle = GetComponent<ParticleSystem>();
    //    particle.gameObject.SetActive(false);
    //}

    // Update is called once per frame
    void Update()
    {
        if ((TimeCounter.timer <= 0) && (flag == true))
        {
            particle.Play();
            flag = false;
            StartCoroutine(ShowMenu());
        }
    }

     IEnumerator ShowMenu()
    {
        yield return new WaitForSeconds(2.0f);
        SceneManager.LoadScene("GameOverScene"); //abre a primeira cena
        yield return 0;
    }

}
