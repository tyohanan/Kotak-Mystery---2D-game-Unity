using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMaster : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject PausePanel;
    public GameObject PlayingPanel;

    private void Start() {
        PausePanel.SetActive(false);
        PlayingPanel.SetActive(true);
    }
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
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


    public void Pause()
    {
        Time.timeScale = 0f;
        GameIsPaused = true;
        PausePanel.SetActive(true);
        PlayingPanel.SetActive(false);
    }

    public void Resume()
    {
        Time.timeScale = 1f;
        GameIsPaused = false;
        PausePanel.SetActive(false);
        PlayingPanel.SetActive(true);
    }


    public void goToGame()
    {
        SceneManager.LoadScene("Level 1");
        Time.timeScale = 1f;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1f;
    }
    

    public void gotoMainMenu()
    {
        SceneManager.LoadScene("MainLevel");
    }
}
