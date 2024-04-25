using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [SerializeField] private GameObject gamePanel;
    [SerializeField] private GameObject pausePanel;
    [SerializeField] private GameObject turrelPanel;

    public void Pause()
    {
        gamePanel.SetActive(false);
        turrelPanel.SetActive(false);
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void BackToGame()
    {
        gamePanel.SetActive(true);
        turrelPanel.SetActive(true);
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}