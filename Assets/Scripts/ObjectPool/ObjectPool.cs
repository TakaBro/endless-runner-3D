using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolItem
{
    public GameObject prefab;
    public int amount;
    public bool expandable;
}

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public List<PoolItem> items;
    public List<GameObject> pooledItems;

    private void Awake()
    {
        Singleton();
        InitPooledItems();
    }

    private void Singleton()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    private void InitPooledItems()
    {
        pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
            }
        }
    }

    public GameObject GetRandom()
    {
        Utils.Shuffle(pooledItems);
        for (int i = 0; i < pooledItems.Count; i++)
        {
            if (!pooledItems[i].activeInHierarchy)
            {
                return pooledItems[i];
            }
        }

        foreach (PoolItem item in items)
        {
            if (item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                pooledItems.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
