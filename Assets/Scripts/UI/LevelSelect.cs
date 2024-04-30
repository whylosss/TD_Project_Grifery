using UnityEngine;
using UnityEngine.SceneManagement;
public class LevelSelect : MonoBehaviour
{
    [SerializeField] private GameObject panelLevel1;
    [SerializeField] private GameObject panelLevel2;
    [SerializeField] private GameObject panelLevel3;

    public void Level1()
    {
        panelLevel1.SetActive(true);
    }

    public void CloseLevel1()
    {
        panelLevel1.SetActive(false);
    }

    public void Level2()
    {
        panelLevel2.SetActive(true);
    }

    public void CloseLevel2()
    {
        panelLevel2.SetActive(false);
    }

    public void Level3()
    {
        panelLevel3.SetActive(true);
    }

    public void CloseLevel3()
    {
        panelLevel3.SetActive(false);
    }

    public void LoadLevel1()
    {
        SceneManager.LoadScene("Level1");
    }

}