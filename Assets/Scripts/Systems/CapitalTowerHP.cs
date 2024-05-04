using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapitalTowerHP : MonoBehaviour, IDeadable
{
    [SerializeField] private float _health;
    [SerializeField] private Text _healthText;

    private void OnEnable()
    {
        AbstractEnemy.TakeTowerHp += GetDamage;
    }

    private void OnDisable()
    {
        
    }

    public void GetDamage(float amount)
    {
       _health -= amount;

        if (_health <= 0)
            Dead();

        _healthText.text = _health.ToString();
    }

    public void Dead()
    {
        SceneManager.LoadScene("Lose");
    }

}
