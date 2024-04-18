using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
public class NavEnemy : MonoBehaviour
{
    private Animator _animator;
    private float _range = 1f;
    private NavMeshAgent _agent;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform _point;
    [SerializeField] private bool canMove = true;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if (canMove == true)
        {
            Move();
        }

        else
            return;

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, _range, ~_enemyLayer))
        {
            if (hit.collider.TryGetComponent(out IDeadable getDamage))
            {
                if (getDamage != null)
                {
                    _animator.SetInteger("destroy", 1);
                    canMove = false;
                }
            }

            else
            {
                _animator.SetInteger("destroy", 0);
                canMove = true;
            }

        }
    }

    private void Move()
    {
        _agent.SetDestination(_point.position);
    }

}
