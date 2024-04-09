using UnityEngine;

public abstract class AbstractTurret : MonoBehaviour
{
    protected Transform _target;
    protected float _range = 40f;
    protected string _enemyTag = "Enemy";
    protected float _fireRate = 1f;
    protected float _countDown = 0f;
    protected int _value;
    public abstract void Shoot();
    public abstract void UpdateTarget();
    public abstract void OnDrawGizmosSelected();
}
