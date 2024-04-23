using UnityEngine;
using UnityEngine.UI;

public class CointSystem : MonoBehaviour
{
    [SerializeField] private Text _cointText;
    public int _coints;

    private void OnEnable()
    {
        Enemy_life.giveMoney += getCoints;
    }

    private void getCoints(int amount)
    {
        _coints += amount;
        _cointText.text = _coints.ToString();
    }

    private void OnDisable()
    {
        Enemy_life.giveMoney -= getCoints;
    }
}
