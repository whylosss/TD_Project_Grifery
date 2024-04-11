using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : AbstractEnemy
{
    [SerializeField] private int _health = 5;
    private void Awake()
    {
        _hp = _health;
    }

    public override void Dead()
    {
        
    }

    public override void GetDamage(int amount)
    {
        
    }
}
