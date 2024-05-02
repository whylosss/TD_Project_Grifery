using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CointSystem : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Text _cointText;
    public int Coins = 30;

    public void Init()
    {
        StartCoroutine(cointUpdate());
        Enemy_life.giveMoney += getCoints;
        _cointText.text = Coins.ToString();
    }

    private void getCoints(int amount)
    {
        Coins += amount;
    }

    private IEnumerator cointUpdate()
    {
        yield return new WaitForSeconds(1f);
        Coins++;
        _cointText.text = Coins.ToString();
        StartCoroutine(cointUpdate());
    }
}
