using System.Collections;
using UnityEngine;

public class Zombi_spawner : MonoBehaviour, IServiceLocator
{
    [SerializeField] private GameObject[] _prefabs;
    [SerializeField] private Transform _spawPosition;
    [SerializeField] private int _startSpawnAmount = 5;
    [SerializeField] private float _spawnInterval = 2.0f;
    [SerializeField] private float _intervalBeetweenWaves = 10.0f;
    [SerializeField] private float _angle;
    [SerializeField] private int _zombiAdd = 5;
    private int _index = 0;
    private int _spawnAmount;
    public void Init()
    { 
        _spawnAmount = _startSpawnAmount;
        StartCoroutine(Spawn());
    }

    private IEnumerator Spawn()
    {
            yield return new WaitForSeconds(_intervalBeetweenWaves);
            while (_spawnAmount > 0)
            {
                _index = Random.Range(0, _prefabs.Length);
                Instantiate(_prefabs[_index], _spawPosition.position, Quaternion.Euler(0, _angle, 0));
                _spawnAmount--;

                yield return new WaitForSeconds(_spawnInterval);
            }

            if (_spawnAmount <= 0)
            {
                _startSpawnAmount += _zombiAdd;
                _spawnAmount = _startSpawnAmount;
                StartCoroutine(Spawn());
            }
    }
}
