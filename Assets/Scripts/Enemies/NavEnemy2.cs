using UnityEngine;
using UnityEngine.AI;
using System.Linq;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemy2 : AbstractEnemy
{
    public static Action <float> TakeTowerHp;

    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 1f;

    private Transform _target;
    private bool _canDestroy = false;

    private void Start()
    {
        _index = 0;
        _damage = damage;
        _range = range;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _point = GameObject.FindGameObjectsWithTag("Point");
        _point = _point.OrderBy(go => go.name).ToArray();
        _target = _point[_index].transform;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
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

        Move();

        if (_canDestroy == true)
        {
            if (Physics.Raycast(ray, out _hit, _range))
            {
                if (_hit.collider.TryGetComponent(out IDeadable getDamage) && _hit.collider.tag != "Enemy")
                {
                    _animator.SetInteger("destroy", 1);
                }
            }
        }

        else
            _animator.SetInteger("destroy", 0);


        if (_index == 8 && _isAlive == true)
        {
            TakeTowerHp?.Invoke(1f);
            _isAlive = false;
            Destroy(gameObject);
        }
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
        if (nearestTurret != null && shortestDistance <= 50f)
        {
            _target = nearestTurret.transform;
            _canDestroy = true;
        }
        else
        {
            _target = _point[_index].transform;
            _canDestroy = false;
        }
    }

    public override void Move()
    {
        if (_target == _point[_index].transform)
        {
            float _distance = UnityEngine.Random.Range(0.01f, 3f);
            {
                if (_agent.remainingDistance <= _distance)
                    _index++;
            }
        }

        _agent.SetDestination(_target.transform.position);
    }


    public override void SendAttack()
    {
        _animator.SetInteger("destroy", 0);

        if (_hit.collider.TryGetComponent(out IDeadable getDamage) && _hit.collider.tag != "Enemy")
        {
             getDamage.GetDamage(_damage);
        }
    }
}
