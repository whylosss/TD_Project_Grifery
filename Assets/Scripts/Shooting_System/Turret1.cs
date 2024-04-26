using UnityEngine;

public class Turret1 : AbstractTurret
{
    [SerializeField] private float HP = 5f;

    [SerializeField] private GameObject _bullet;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float CountDown = 0f;
    [SerializeField] private float Range = 40;
    [SerializeField] private float FireRate = 1f;

    [SerializeField] private int Value = 15;

    [SerializeField] private string EnemyTag = "Enemy";

    private void Awake()
    {
        _health = HP;
        _range = Range;
        _enemyTag = EnemyTag;
        _fireRate = FireRate;
        _countDown = CountDown;
        _value = Value;

        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    private void Update()
    {
        if (_target == null)
            return;
        else
        {
            Vector3 targetDirection = _target.position - transform.position;
            transform.rotation = Quaternion.LookRotation(targetDirection);
        }

        if (_countDown <= 0f)
        {
            Shoot();
            _countDown = 1f / _fireRate;
        }

        _countDown -= Time.deltaTime;
    }

    public override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(_bullet, _spawnPosition.position, Quaternion.Euler(90f, 0f, 0f));
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    public override void UpdateTarget()
    {
        GameObject[] enemyArray = GameObject.FindGameObjectsWithTag(_enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemyArray)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= _range)
        {
            _target = nearestEnemy.transform;
        }
        else
        {
            _target = null;
        }

    }

    public override void GetDamage(float amount)
    {
        _health -= amount;
        if(_health <= amount)
        {
            Dead();
        }
    }

    public override void Dead()
    {
       Destroy(gameObject);
    }

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }

  
}
