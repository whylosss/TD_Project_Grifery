using UnityEngine;

[RequireComponent(typeof(AudioSource))]

public class Turret : MonoBehaviour , IShootable
{
    private AudioSource _audioSource;
    private const string _enemyTag = "Enemy";

    [SerializeField] private GameObject _bullet;

    [SerializeField] private Transform _spawnPosition;
    [SerializeField] private float _countDown = 0f;
    [SerializeField] private float _range = 40;
    [SerializeField] private float _fireRate = 1f;

    private Transform _target;

    public int _value = 15;

    private void Start()
    { 
        _audioSource = GetComponent<AudioSource>();
        _audioSource.volume = 0.1f;
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

    public void Shoot()
    {
        _audioSource.Play();    
        GameObject bulletGO = Instantiate(_bullet, _spawnPosition.position, Quaternion.Euler(90f, 0f, 0f));
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    public void UpdateTarget()
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
