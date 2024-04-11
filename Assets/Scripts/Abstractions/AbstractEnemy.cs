using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, IDeadable
{
    protected int _hp;
    public abstract void Dead();
    public abstract void GetDamage(int amount);
}
    
