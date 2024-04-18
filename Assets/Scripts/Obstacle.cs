using UnityEngine;

public class Obstacle : MonoBehaviour, IDeadable
{
    private float _hp = 5;

    public void Dead()
    {
       Destroy(gameObject);
    }

    public void GetDamage(float amount)
    {
        _hp -= amount;
    }
}
