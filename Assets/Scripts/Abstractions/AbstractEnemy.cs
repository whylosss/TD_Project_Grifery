using UnityEngine;

public abstract class AbstractEnemy : MonoBehaviour, IDeadable
{
    protected int HP;
    public abstract void Dead();
    public abstract void GetDamage(int amount);
}
    
