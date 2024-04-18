using UnityEngine;

public class Turret1 : AbstractTurret
{
    [SerializeField] private GameObject _bullet;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float CountDown = 0f;
    [SerializeField] private float Range = 40;
    [SerializeField] private float FireRate = 1f;

    [SerializeField] private int Value = 15;

    [SerializeField] private string EnemyTag = "Enemy";

    //private List<GameObject> _bulletsPool = new List<GameObject>();
    //private int _bulletsAmount = 20;

    //public static Turret1 Instance;
    //private void Awake()
    //{
    //    _range = Range;
    //    _enemyTag = EnemyTag;
    //    _fireRate = FireRate;
    //    _countDown = CountDown;
    //    _value = Value;

    //    InvokeRepeating("UpdateTarget", 0f, 0.5f);

    //    if (Instance == null)
    //        Instance = this;
    //}

    //private void Start()
    //{
    //    for (int i = 0; i < _bulletsAmount; i++)
    //    {
    //        GameObject obj = Instantiate(_bullet);
    //        obj.SetActive(false);
    //        _bulletsPool.Add(obj);
    //    }
    //}

    //private void Update()
    //{
    //    if (_target == null)
    //        return;
    //    else
    //    {
    //        Vector3 targetDirection = _target.position - transform.position;
    //        transform.rotation = Quaternion.LookRotation(targetDirection);
    //    }

    //    if (_countDown <= 0f)
    //    {
    //        Shoot();
    //        _countDown = 1f / _fireRate;
    //    }

    //    _countDown -= Time.deltaTime;
    //}

    //public GameObject GetPooledObject()
    //{
    //    for(int i = 0; i < _bulletsPool.Count; i++)
    //    {
    //        if (!_bulletsPool[i].activeInHierarchy)
    //        {
    //            return _bulletsPool[i];
    //        }
    //    }
    //    return null;
    //}

    //public override void UpdateTarget()
    //{
    //    GameObject[] enemyArray = GameObject.FindGameObjectsWithTag(_enemyTag);
    //    float shortestDistance = Mathf.Infinity;
    //    GameObject nearestEnemy = null;
    //    foreach (GameObject enemy in enemyArray)
    //    {
    //        float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
    //        if (distanceToEnemy < shortestDistance)
    //        {
    //            shortestDistance = distanceToEnemy;
    //            nearestEnemy = enemy;
    //        }
    //    }
    //    if (nearestEnemy != null && shortestDistance <= _range)
    //    {
    //        _target = nearestEnemy.transform;
    //    }
    //    else
    //    {
    //        _target = null;
    //    }
    //}

    //public override void Shoot()
    //{
    //    GameObject bulletGO = Turret1.Instance.GetPooledObject();
    //    if (bulletGO != null)
    //    {
    //        _bullet.transform.position = _spawnPosition.position;
    //        _bullet.SetActive(true);   
    //    }

    //    Bullet bullet = bulletGO.GetComponent<Bullet>();

    //    if (bullet != null)
    //    {
    //        bullet.Seek(_target);
    //    }
    //}

    private void Awake()
    {
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

    protected override void OnDrawGizmosSelected()
    {
        base.OnDrawGizmosSelected();
    }
}
