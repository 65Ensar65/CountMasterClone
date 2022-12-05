using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjectPool : MonoBehaviour, IEnemyObjectPool
{
    [Serializable]
    public class Pool
    {
        public ObjectTags objectTag;
        public int size;
        public GameObject PlayerPrefab;
    }

    public Dictionary<ObjectTags, Queue<GameObject>> keyValue;
    public List<Pool> Pools;
   


    private void OnEnable()
    {
        GetPoolManager();
        
    }
    public void GetPoolManager()
    {
        keyValue = new Dictionary<ObjectTags, Queue<GameObject>>();

        foreach (Pool pool in Pools)
        {
            Queue<GameObject> Object = new Queue<GameObject>();

            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.PlayerPrefab);
                obj.SetActive(true);
                obj.transform.localPosition = transform.position;
                obj.transform.parent = transform;
                Object.Enqueue(obj);
            }
            keyValue.Add(pool.objectTag, Object);
        }
    }

    
    public GameObject ActivePoolObject(ObjectTags poolTag, int size, Transform player)
    {
        if (!keyValue.ContainsKey(poolTag))
        {
            return null;
        }

        GameObject obj = null;

        obj = keyValue[poolTag].Dequeue();
        obj.SetActive(true);
        obj.transform.position = player.position;
        obj.transform.parent = player.transform;

        return obj;

    }

    public GameObject ReturnPoolObject(ObjectTags tag, GameObject obj)
    {
        if (!keyValue.ContainsKey(tag))
        {
            return null;
        }

        keyValue[tag].Enqueue(obj);
        obj.SetActive(false);
        transform.parent = transform;
        obj.transform.position = transform.position;

        return obj;
    }
}
public enum ObjectTags
{
    Enemy
}
