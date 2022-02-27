using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject instructionsPanel;


    public void Play()
    {
        SceneManager.LoadScene("GameplayScene");   
    }

    public void ShowMainMenuPanel()
    {
        mainMenuPanel.SetActive(true);
        creditsPanel.SetActive(false);
        instructionsPanel.SetActive(false);
    }

    public void ShowCreditsPanel()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(true);
        instructionsPanel.SetActive(false);
    }

    public void ShowInstructionsPanel()
    {
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        instructionsPanel.SetActive(true);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
