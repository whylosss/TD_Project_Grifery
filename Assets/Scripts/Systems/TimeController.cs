using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;

public class TimeController : MonoBehaviour
{
    public static Action playPhrase;

    [SerializeField] private Text _timeText;
    [SerializeField] private int _time = 120;

    public void Init()
    {
        StartCoroutine(timeUpdate());
    }


    private IEnumerator timeUpdate()
    {
        yield return new WaitForSeconds(1f);
        _time--;
        _timeText.text = _time.ToString();
        StartCoroutine(timeUpdate());

        if (_time <= 0)
            SceneManager.LoadScene("Win");

        if(_time == 60)
            playPhrase?.Invoke();

    }
}
