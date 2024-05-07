using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerHP : MonoBehaviour, IDeadable
{
    public static Action setDestoyState;

    [SerializeField] private float _hp = 5f;

    public void Dead()
    {
        setDestoyState?.Invoke();
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
