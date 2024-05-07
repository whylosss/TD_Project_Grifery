using System;
using UnityEngine;
using UnityEngine.AI;

public abstract class AbstractEnemy : MonoBehaviour, IMovable
{

    protected Animator _animator;
    protected NavMeshAgent _agent;

    protected int _damage;
    protected float _range;
    protected int _index = -1;

    protected bool _isAlive = true;
    protected bool _canMove = true;

    protected GameObject[] _points;

    protected RaycastHit _hit;

    public abstract void Move();
    public abstract void SendAttack();
   
}
    
