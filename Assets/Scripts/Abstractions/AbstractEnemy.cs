using UnityEngine;
using UnityEngine.AI;
using System;

public abstract class AbstractEnemy : MonoBehaviour, IMovable
{
    public static Action<float> TakeTowerHp;

    protected Animator _animator;
    protected NavMeshAgent _agent;

    protected int _damage;
    protected float _range;
    protected int _index = -1;

    protected bool _canMove = true;

    protected GameObject[] _point;

    protected RaycastHit _hit;

    public abstract void Move();
    public abstract void SendAttack();
   
}
    
