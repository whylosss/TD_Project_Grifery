using UnityEngine;

public class Enemy2_life : AbstractEnemy
{
    [SerializeField] private int _costKill = 10;
    [SerializeField] private float _health = 10f;
    private void Awake()
    {
        _getMoneyForKill = _costKill;
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
