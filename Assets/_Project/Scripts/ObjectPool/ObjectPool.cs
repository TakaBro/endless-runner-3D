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
    [SerializeField] public List<PoolItem> items;
    private List<GameObject> _pooledItems;

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
        _pooledItems = new List<GameObject>();
        foreach (PoolItem item in items)
        {
            for (int i = 0; i < item.amount; i++)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                _pooledItems.Add(obj);
            }
        }
    }

    public GameObject GetRandom()
    {
        Utils.Shuffle(_pooledItems);
        for (int i = 0; i < _pooledItems.Count; i++)
        {
            if (!_pooledItems[i].activeInHierarchy)
            {
                return _pooledItems[i];
            }
        }

        foreach (PoolItem item in items)
        {
            if (item.expandable)
            {
                GameObject obj = Instantiate(item.prefab);
                obj.SetActive(false);
                _pooledItems.Add(obj);
                return obj;
            }
        }
        return null;
    }
}
