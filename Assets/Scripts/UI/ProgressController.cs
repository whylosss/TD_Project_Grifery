using UnityEngine;
using UnityEngine.UI;

public class ProgressController : MonoBehaviour
{

    [SerializeField] private Text scoreText;
    private int Score = 0;

    public void AddProgress(int score)
    {
        Score += score;
        scoreText.text = Score.ToString();
    }

}