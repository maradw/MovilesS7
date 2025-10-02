using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ObjectPooling", menuName = "ObjectPooling/SimpleObjectPooling", order = 5)]
public class SimpleObjectPooling : ScriptableObject
{
    [SerializeField] private GameObject objectPrefab;
    private Queue<GameObject> objectPool;
    private Transform parentTransform;

    public event Action onEnableObject;

    public void SetUp(Transform parent)
    {
        if (objectPool == null)
        {
            objectPool = new Queue<GameObject>();
        }

        objectPool.Clear();
        parentTransform = parent;
    }

    public GameObject GetObject()
    {
        GameObject objectInstance = null;

        if (objectPool.Count > 0)
        {
            objectInstance = objectPool.Dequeue();
            objectInstance.SetActive(true);
            onEnableObject?.Invoke();
        }
        else
        {
            objectInstance = Instantiate(objectPrefab, parentTransform.position, Quaternion.identity);
           // objectInstance.transform.SetParent(parentTransform, true);
            objectInstance.SetActive(true);
            onEnableObject?.Invoke();
        }

        return objectInstance;
    }

    public void ObjectReturn(GameObject objectInstance)
    {
        objectInstance.SetActive(false);
        objectInstance.transform.position = parentTransform.transform.position;
        objectPool.Enqueue(objectInstance);
    }
}
