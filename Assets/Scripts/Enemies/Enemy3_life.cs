using UnityEngine;

public class Enemy3_life : AbstractEnemy
{
    [SerializeField] private float _health = 15f;
    [SerializeField] private int _killCost = 15;
    private void Awake()
    {
        _getMoneyForKill = _killCost;
        _hp = _health;
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    public override void Dead() 
    {
        _animator.SetBool("dead", true);
        Destroy(_collider);
        Destroy(gameObject, 2f);
    }

    public override void GetDamage(float amount)
    {
        _hp -= amount;
        if (_hp <= 0)
        {
            Dead();
        }
    }

    private void OnDestroy()
    {
        giveMoney?.Invoke(_getMoneyForKill);
    }
}
