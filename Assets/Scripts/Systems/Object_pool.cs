using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object_pool : MonoBehaviour
{
    public static Object_pool Instance;

    private List<GameObject> pooledObjects = new List<GameObject>();
    [SerializeField] private int _objectsToSpawn = 100;

    [SerializeField] private GameObject _objectPrefs;

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
            GameObject obj = Instantiate(_objectPrefs);
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }
    }

    public GameObject GetObject()
    {
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            if (!pooledObjects[i].activeSelf)
            {
                return pooledObjects[i];
            }
        }
        return null;
    }
}
