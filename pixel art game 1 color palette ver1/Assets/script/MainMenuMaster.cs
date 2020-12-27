using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuMaster : MonoBehaviour
{
    public GameObject MainMenuPanel;
    public GameObject LevelMenuPanel;
    public GameObject aboutPanel;

    void Start()
    {
        MainMenuPanel.SetActive(true);
        LevelMenuPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void levelMenuPanel()
    {
        MainMenuPanel.SetActive(false);
        LevelMenuPanel.SetActive(true);
        aboutPanel.SetActive(false);
    }

    public void AboutPanel()
    {
        MainMenuPanel.SetActive(false);
        LevelMenuPanel.SetActive(false);
        aboutPanel.SetActive(true);
    }

    public void BackButton()
    {
        MainMenuPanel.SetActive(true);
        LevelMenuPanel.SetActive(false);
        aboutPanel.SetActive(false);
    }

    public void gotoLevel1()
    {
        SceneManager.LoadScene("Level 1");
    }

    public void gotoLevel2()
    {
        SceneManager.LoadScene("Level 2");
    }

    public void gotoLevel3()
    {
        SceneManager.LoadScene("Level 3");
    }

    public void gotoLevel4()
    {
        SceneManager.LoadScene("Level 4");
    }

    public void gotoLevel5()
    {
        SceneManager.LoadScene("Level 5");
    }
}
