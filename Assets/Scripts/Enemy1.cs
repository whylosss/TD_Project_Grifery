using UnityEngine;

public class Enemy1 : AbstractEnemy
{
    [SerializeField] private int _health = 5;
    private Animator _animator;
    private Collider _collider;
    private void Awake()
    {
        _hp = _health;
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    public override void Dead()
    {
        
    }

    public override void GetDamage(float amount)
    {
        
    }
}
