using UnityEngine;
using UnityEngine.UI;

public class CointSystem : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Text _cointText;
    public int _coints;

    public void Init()
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
