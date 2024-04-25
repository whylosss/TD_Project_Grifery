using UnityEngine;
using UnityEngine.AI;
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(NavMeshAgent))]
public class NavEnemy1 : AbstractEnemy
{
    [SerializeField] private int damage = 1;
    [SerializeField] private float range = 1f;


    private void Awake()
    { 
        _damage = damage;
        _range = range;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        _point = GameObject.FindGameObjectWithTag("Point");
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
        Debug.DrawRay(transform.position, transform.forward * 3f, Color.red);

        if (_canMove == true)
        {
            Move();
        }
        
        else
            return;

        if (Physics.Raycast(ray, out _hit, _range))
        {
            Debug.Log("Text");
            if (_hit.collider.TryGetComponent(out IDeadable getDamage))
            {
                if (getDamage != null)
                {
                    _animator.SetInteger("destroy", 1);
                    _canMove = false;
                }
            }
        }
    }

    public override void Move()
    {
        _agent.SetDestination(_point.transform.position);
    }


    public override void SendAttack()
    {
        if (_hit.collider.TryGetComponent(out IDeadable sendDamage))
        {
            if (sendDamage != null)
            {
                sendDamage.GetDamage(damage);
                Debug.Log("Дамаг пройшов");
            }
        }
            _canMove = true;
            _animator.SetInteger("destroy", 0);
    }
}
