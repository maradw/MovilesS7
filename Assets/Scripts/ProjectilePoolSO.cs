using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "ProjectilePool", menuName = "Pooling/Projectile Pool SO")]
public class ProjectilePoolSO : ScriptableObject
{
    [SerializeField] private GameObject itemPrefab;
    [SerializeField] private int initialSize = 10;

    private List<GameObject> pooledObjects = new List<GameObject>();
    private Transform poolParent;

    private bool isInitialized = false;

    public void InitializePool()
    {
        if (isInitialized) return;

        GameObject parentObj = new GameObject("ProjectilePool_" + itemPrefab.name);
        poolParent = parentObj.transform;

        for (int i = 0; i < initialSize; i++)
        {
            GameObject obj = CreateNewObject();
            obj.SetActive(false);
            pooledObjects.Add(obj);
        }

        isInitialized = true;
    }

    public GameObject GetPooledObject()
    {
        if (!isInitialized)
        {
            InitializePool();
        }
        for (int i = 0; i < pooledObjects.Count; i++)
        {
            GameObject go = pooledObjects[i];

            if (go == null)
            {
                pooledObjects.RemoveAt(i);
                i--;
               
            }

            if (!go.activeInHierarchy)
            {
                return go;
            }
        }
        GameObject newObj = Instantiate(itemPrefab);
        newObj.SetActive(false);
        pooledObjects.Add(newObj);
        return newObj;
    }
    public void ReturnToPool(GameObject projectile)
    {
        projectile.SetActive(false);
    }
    private GameObject CreateNewObject()
    {
        GameObject obj = GameObject.Instantiate(itemPrefab);
        obj.transform.SetParent(poolParent);
        return obj;
    }
}
