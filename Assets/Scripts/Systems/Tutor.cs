using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutor : MonoBehaviour
{
    [SerializeField] private GameObject panel1;
    [SerializeField] private GameObject panel2;

    private void Start()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void Next()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

    public void Previous()
    {
        panel1.SetActive(true);
        panel2.SetActive(false);
    }

    public void Back()
    {
        SceneManager.LoadScene("LevelSelection");
    }
}
