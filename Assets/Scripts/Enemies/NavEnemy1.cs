using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemy1 : AbstractEnemy
{
    public static Action<float> TakeTowerHp;

    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 1f;

    private void Start()
    {
        _damage = damage;
        _range = range;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _point = GameObject.FindGameObjectsWithTag("Point");
        _point = _point.OrderBy(go => go.name).ToArray();

    }

    private void Update()
    {
        Move();

        if (_index == 8 && _isAlive == true)
        {
            TakeTowerHp?.Invoke(1f);
            _isAlive = false;
            Destroy(gameObject);
        }

    }

    public override void Move()
    {
        float _distance = UnityEngine.Random.Range(0.01f, 3f);

        if (_agent.remainingDistance <= _distance)
            _index++;

        _agent.SetDestination(_point[_index].transform.position);
    }


    public override void SendAttack()
    {
        return;
    }
}
