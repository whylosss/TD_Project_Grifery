using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemy1 : AbstractEnemy
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 1f;

    private void Start()
    {
        _damage = damage;
        _range = range;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _point = GameObject.FindGameObjectWithTag("Point");
    }

    private void Update()
    {
        Move();
    }

    public override void Move()
    {
        _agent.SetDestination(_point.transform.position);
    }


    public override void SendAttack()
    {
        return;
    }
}
