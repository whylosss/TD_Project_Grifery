using System;
using UnityEngine;
[RequireComponent(typeof(Animator))]
public class Enemy_life : MonoBehaviour, IDeadable
{
    public static Action<int> giveMoney;

    private Collider _collider;
    private Animator _animator;
    [SerializeField] private float _health = 5f;
    [SerializeField] private int _killCost = 5;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _animator = GetComponent<Animator>();
    }

    public void Dead()
    {
        _animator.SetBool("dead", true);
        Destroy(_collider);
        Destroy(gameObject, 2f);
        giveMoney?.Invoke(_killCost);
    }

    public void GetDamage(float amount)
    {
        _health -= amount;
        if (_health <= 0f )
        {
            Dead();
        }
    }
}
