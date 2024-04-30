using System.Collections;
using UnityEngine;

public class Zombi_spawner : MonoBehaviour, IServiceLocator
{
    [SerializeField] private Transform _spawPosition;
    private int _startSpawnAmount = 5;
    [SerializeField] private int _spawnAmount;
    [SerializeField] private float _spawnInterval = 2.0f;
    [SerializeField] private float _intervalBeetweenWaves = 10.0f;
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
            GameObject zombi = zombi_object_pool.Instance.GetObject();
            if(zombi != null)
            {
                zombi.transform.position = _spawPosition.position;
                zombi.transform.rotation = Quaternion.Euler(0, 180, 0);
                zombi.SetActive(true);
                _spawnAmount--;
            }
            yield return new WaitForSeconds(_spawnInterval);
        }

        if(_spawnAmount <= 0)
        {
            _startSpawnAmount += 5;
            _spawnAmount = _startSpawnAmount;
            StartCoroutine(Spawn());
        }
    }

}
