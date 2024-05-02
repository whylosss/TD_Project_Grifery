using UnityEngine;
using UnityEngine.UI;

public class CointSystem : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Text _cointText;
    public int _coints;

    public void Init()
    {
        UpdateCoints();
        Enemy_life.giveMoney += getCoints;
        BuildTower.onSpent += UpdateCoints;
    }

    private void UpdateCoints()
    {
        _cointText.text = _coints.ToString();
    }

    private void getCoints(int amount)
    {
        _coints += amount;
        UpdateCoints();
    }

    private void OnDisable()
    {
        BuildTower.onSpent -= UpdateCoints;
        Enemy_life.giveMoney -= getCoints;
    }
}
