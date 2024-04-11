using System;
using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, IDeadable
{
    public static Action<int> giveMoney;

    protected int _hp;
    protected bool canRotate = true;
    public abstract void Dead();
    public abstract void GetDamage(float amount);
}
    
