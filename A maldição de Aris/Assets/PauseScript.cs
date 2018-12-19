using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public AudioClip _audioButton;

    // Update is called once per frame
    void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void MenuButton()
    {
        GetComponent<AudioSource>().PlayOneShot(_audioButton);
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitButton()
    {
        GetComponent<AudioSource>().PlayOneShot(_audioButton);
        Application.Quit();
    }
}
