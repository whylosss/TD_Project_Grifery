using UnityEngine;

public abstract class AbstractTurret : MonoBehaviour, IShootable, IDeadable
{

    protected Transform _target;

    protected float _range;
    protected float _fireRate;
    protected float _countDown;

    protected float _health;
    public int _value;

    protected string _enemyTag;

    public abstract void Shoot();
    public abstract void UpdateTarget();
    public abstract void GetDamage(float amount);
    public abstract void Dead();
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
