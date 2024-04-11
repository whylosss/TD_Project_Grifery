using UnityEngine;

public abstract class AbstractTurret : MonoBehaviour, IShootable
{
    protected Transform _target;

    protected float _range;
    protected float _fireRate;
    protected float _countDown;

    protected int _value;

    protected string _enemyTag;

    public abstract void Shoot();
    public abstract void UpdateTarget();
    protected virtual void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
