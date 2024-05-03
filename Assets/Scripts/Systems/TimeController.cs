using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private float _time = 120;

    private void Update()
    {
        _time -= Time.deltaTime;
        _timeText.text = ToString();

        if ( _time <= 0 )
            SceneManager.LoadScene("");
    }
}
