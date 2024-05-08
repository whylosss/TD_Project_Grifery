using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject panelLevel1;
    [SerializeField] private GameObject panelLevel2;
    [SerializeField] private GameObject panelLevel3;

    public void Level1()
    {
        panel.SetActive(false);
        panelLevel1.SetActive(true);
    }

    public void CloseLevel1()
    {
        panel.SetActive(true);
        panelLevel1.SetActive(false);
    }

    public void Level2()
    {
        panel.SetActive(false);
        panelLevel2.SetActive(true);
    }

    public void CloseLevel2()
    {
        panel.SetActive(true);
        panelLevel2.SetActive(false);
    }

    public void Level3()
    {
        panel.SetActive(false);
        panelLevel3.SetActive(true);
    }

    public void CloseLevel3()
    {
        panel.SetActive(true);
        panelLevel3.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

    public void LoadTutor()
    {
        SceneManager.LoadScene("Tutorial");
    }

}