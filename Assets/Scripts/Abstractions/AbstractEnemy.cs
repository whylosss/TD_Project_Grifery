using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractEnemy : MonoBehaviour, IMovable
{
    protected Animator _animator;
    protected NavMeshAgent _agent;

    protected int _damage;
    protected float _range;

    protected GameObject _point;
    protected bool _canMove = true;

    protected RaycastHit _hit;

    public abstract void Move();
    public abstract void SendAttack();
   
}
    
