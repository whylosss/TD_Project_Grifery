using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject mainPanel;
    [SerializeField] private GameObject settingsPanel;

    [SerializeField] private Button btn;


    public void LoadGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void Settings()
    {
        mainPanel.SetActive(false);
        settingsPanel.SetActive(true);
    }

    public void Back()
    {
        mainPanel.SetActive(true);
        settingsPanel.SetActive(false);
    }

    public void Quit()
    {
        btn.GetComponent<Image>().color = Color.red;
        Application.Quit();
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