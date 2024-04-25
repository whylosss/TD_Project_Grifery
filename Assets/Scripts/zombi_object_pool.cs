using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zombi_object_pool : MonoBehaviour
{
    public static zombi_object_pool Instance;

    private List<GameObject> pooledZombies = new List<GameObject>();
    private int _objectsToSpawn = 100;

    [SerializeField] private GameObject _zombiPrefs;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        for (int i = 0; i < _objectsToSpawn; i++)
        {
            GameObject obj = Instantiate(_zombiPrefs);
            obj.SetActive(false);
            pooledZombies.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pooledZombies.Count; i++)
        {
            if (!pooledZombies[i].activeSelf)
            {
                return pooledZombies[i];
            }
        }
        return null;
    }
}
