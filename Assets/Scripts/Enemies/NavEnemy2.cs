using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemy2 : AbstractEnemy
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 1f;

    private Transform _target;

    private void Awake()
    {
        _damage = damage;
        _range = range;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _point = GameObject.FindGameObjectWithTag("Point");
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        //_animator.applyRootMotion = false;
    }

    private void OnEnable()
    {
        AnimEvent.checkRay += SendAttack;
    }

    private void OnDisable()
    {
        AnimEvent.checkRay -= SendAttack;
    }

    private void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        Debug.DrawRay(transform.position, transform.forward * 1f, Color.red);

        if (_canMove == true)
        {
            Move();
        }

        else
            return;

        if (Physics.Raycast(ray, out _hit, _range))
        {
            if (_hit.collider.TryGetComponent(out IDeadable getDamage))
            {
                if (getDamage != null )
                {
                    _animator.SetInteger("destroy", 1);
                    _canMove = false;
                }
            }
        }

        //if (_agent.remainingDistance <= 0.5f)
        //    _canMove = false;

    }

    private void UpdateTarget()
    {
        GameObject[] turretsArray = GameObject.FindGameObjectsWithTag("Turret");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestTurret = null;
        foreach (GameObject turret in turretsArray)
        {
            float distanceToTurret = Vector3.Distance(transform.position, turret.transform.position);
            if (distanceToTurret < shortestDistance)
            {
                shortestDistance = distanceToTurret;
                nearestTurret = turret;
            }
        }
        if (nearestTurret != null && shortestDistance <= 1000f)
        {
            _target = nearestTurret.transform;
        }
        else
        {
            _target = _point.transform;
        }

    }

    public override void Move()
    {
        _agent.SetDestination(_target.transform.position);
    }


    public override void SendAttack()
    {
        if (_hit.collider.TryGetComponent(out IDeadable getDamage))
        {
            if (getDamage != null)
            {
                getDamage.GetDamage(_damage);
                Debug.Log("Дамаг по вежі пройшов");
            }
        }
        _canMove = true;
        _animator.SetInteger("destroy", 0);
    }
}
