using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;

    public void Pause()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gamePanel.SetActive(false);
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void BackToGame()
    {
        gamePanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}