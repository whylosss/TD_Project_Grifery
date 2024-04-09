using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret1 : AbstractTurret
{
    [SerializeField] private GameObject _bullet;
    [SerializeField] private Transform _spawnPosition;
    private void Awake()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);

        _range = 40f;
        _enemyTag = "Enemy";
        _fireRate = 1f;
        _countDown = 0f;
        _value = 15;
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

    public override void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(_bullet, _spawnPosition.position, Quaternion.Euler(90f, 0f, 0f));
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(_target);
        }
    }

    public override void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _range);
    }
}
