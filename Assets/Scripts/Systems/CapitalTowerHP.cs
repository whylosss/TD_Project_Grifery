using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CapitalTowerHP : MonoBehaviour, IDeadable
{
    [SerializeField] private float _health = 10;
    [SerializeField] private Text _healthText;

    private void OnEnable()
    {
        _healthText.text = _health.ToString();
        NavEnemy1.TakeTowerHp += GetDamage;
        NavEnemy2.TakeTowerHp += GetDamage;
        _healthText.text = _health.ToString();
    }

    private void OnDisable()
    {
        NavEnemy1.TakeTowerHp -= GetDamage;
        NavEnemy2.TakeTowerHp -= GetDamage;
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
