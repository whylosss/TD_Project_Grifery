using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombi_object_pool : MonoBehaviour, IServiceLocator
{
    public static zombi_object_pool Instance;

    private List<GameObject> pooledZombies = new List<GameObject>();
    private int _objectsToSpawn = 100;

    [SerializeField] private GameObject[] _zombiPrefs;

    public void Init1()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Init2()
    {
        for (int i = 0; i < _objectsToSpawn; i++)
        {
            GameObject obj1 = Instantiate(_zombiPrefs[0]);
            obj1.SetActive(false);
            pooledZombies.Add(obj1);
        }

        for (int i = 0; i < _objectsToSpawn; i++)
        {
            GameObject obj2 = Instantiate(_zombiPrefs[1]);
            obj2.SetActive(false);
            pooledZombies.Add(obj2);
        }

        for (int i = 0; i < _objectsToSpawn; i++)
        {
            GameObject obj3 = Instantiate(_zombiPrefs[2]);
            obj3.SetActive(false);
            pooledZombies.Add(obj3);
        }
    }

    public GameObject GetObject()
    {
        int randomIndex = Random.Range(0, pooledZombies.Count);
        for (int i = randomIndex; i < pooledZombies.Count; i++)
        {
            if (!pooledZombies[i].activeSelf)
            {
                return pooledZombies[i];
            }
        }
        return null;
    }
}
