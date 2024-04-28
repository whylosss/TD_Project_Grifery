using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombi_object_pool : MonoBehaviour
{
    public static zombi_object_pool Instance;

    private List<GameObject> pooledZombies = new List<GameObject>();
    private int _objectsToSpawn = 50;

    [SerializeField] private GameObject[] _zombiPrefs;

    private void Awake()
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

    private void Start()
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
