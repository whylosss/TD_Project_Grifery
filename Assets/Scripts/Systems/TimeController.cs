using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TimeController : MonoBehaviour
{
    [SerializeField] private Text _timeText;
    [SerializeField] private int _time = 120;

    public void Init()
    {
        StartCoroutine(timeUpdate());
    }

    private void Update()
    {
        if ( _time <= 0 )
            SceneManager.LoadScene("Win");
    }

    private IEnumerator timeUpdate()
    {
        yield return new WaitForSeconds(1f);
        _time--;
        _timeText.text = _time.ToString();
        StartCoroutine(timeUpdate());
    }
}
