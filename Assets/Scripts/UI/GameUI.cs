using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour, IServiceLocator
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject turrelPanel;
    [SerializeField] private GameObject settingsPanel;
    private bool PauseGame;

    public void Init()
    {
        gamePanel.SetActive(true);
        turrelPanel.SetActive(true);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseGame)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        gamePanel.SetActive(false);
        turrelPanel.SetActive(false);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
        PauseGame = true;
    }

    public void Continue()
    {
        gamePanel.SetActive(true);
        turrelPanel.SetActive(true);
        settingsPanel.SetActive(false);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        PauseGame = false;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 0);
    }

    public void Settings()
    {
        gamePanel.SetActive(false);
        turrelPanel.SetActive(false);
        pausePanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void BackToPause()
    {
        gamePanel.SetActive(false);
        turrelPanel.SetActive(false);
        pausePanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void SetLowSettings()
    {
        QualitySettings.SetQualityLevel(0, true);
    }

    public void SetMediumSettings()
    {
        QualitySettings.SetQualityLevel(2, true);
    }

    public void SetHighSettings()
    {
        QualitySettings.SetQualityLevel(5, true);
    }
}