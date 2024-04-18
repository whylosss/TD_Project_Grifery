using UnityEngine;
using UnityEngine.UI;

public class CointSystem : MonoBehaviour
{
    [SerializeField] private Text _cointText;
    public int _coints;

    private void OnEnable()
    {
        AbstractEnemy.giveMoney += getCoints;
    }

    private void getCoints(int amount)
    {
        _coints += amount;
        _cointText.text = _coints.ToString();
    }

    private void OnDisable()
    {
        AbstractEnemy.giveMoney -= getCoints;
    }
}
