using UnityEngine;

public class Obstacle : MonoBehaviour, IDeadable
{
    [SerializeField] private float _hp = 5f;

    public void Dead()
    {
       Destroy(gameObject);
    }

    public void GetDamage(float amount)
    {
        _hp -= amount;
        if (_hp <= 0f)
        {
            _hp = 0f;
            Dead();
        }
    }
}
