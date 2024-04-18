using UnityEngine;
using UnityEngine.AI;
//[RequireComponent(typeof(Animator))] 
public class NavEnemy : MonoBehaviour
{
    //    private Animator _animator;
    private float _range = 1f;
    private NavMeshAgent _agent;
    private float _stopDistance = 0.1f;
    [SerializeField] private int _index = 0;
    [SerializeField] private LayerMask _enemyLayer;
    [SerializeField] private Transform[] _points;
    [SerializeField] private bool canMove = true;

    private void Awake()
    {
        //_animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _agent.SetDestination(_points[_index].position);
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
                    //_animator.SetBool("Destroy", true);
                    canMove = false;
                }
            }

            else
            {
                //_animator.SetBool("Destroy", false);
                canMove = true;
            }
                
        }
    }

    private void Move()
    {
        _agent.SetDestination(_points[_index].position);
        if (_agent.remainingDistance <= _stopDistance)
        {
            _index++;
        }

        if(_index >= _points.Length)
        {
            Destroy(gameObject);
        }
    }

}
