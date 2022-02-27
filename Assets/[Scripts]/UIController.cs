using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour
{
    public static UIController Instance;
    public TMP_Text scoreText;
    public TMP_Text timerText;
    public TMP_Text finalScoreText;

    public GameObject pauseMenu;
    public GameObject endMenu;
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + GameManager.Instance.score;
        int min = (int)GameManager.Instance.timer / 60;
        int sec = (int)GameManager.Instance.timer % 60;

        timerText.text = min + "." + sec;
    }

    public void ResumeButtonPressed()
    {
        GameManager.Instance.ResumeGame();
    }

    public void QuitButtonPressed()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void UpdateFinalScore()
    {
        finalScoreText.text = "Final Score: " + GameManager.Instance.score;
    }
}
