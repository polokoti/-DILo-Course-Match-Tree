﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [System.Serializable]
    public class Pool
    {
        public string tag;
        public GameObject prefab;
        public int size;
    }

    // untuk memuat prefab pool
    public List<Pool> pools;
    
    public Dictionary<string, Queue<GameObject>> poolDictionary;

    //Singleton untuk objek pooler
    public static ObjectPooler Instance;

    void Awake()
    {
        Instance = this;
        poolDictionary = new Dictionary<string, Queue<GameObject>>();
        AddIntoPool();
    }

    //AddIntoPool untuk menambahkan prefab objek ke dalam pool
    void AddIntoPool()
    {
        pools.ForEach((pool) =>
        {
            Queue<GameObject> objectPool = new Queue<GameObject>();

            int i = 0;
            while (i < pool.size)
            {
                GameObject obj = Instantiate(pool.prefab);
                obj.SetActive(false);
                objectPool.Enqueue(obj);
                i++;
            }

            poolDictionary.Add(pool.tag, objectPool);
        });
    }

    //SpawnFromPool digunakan untuk mengambil objek dari pool
    public GameObject SpawnFormPool(string tag, Vector3 position, Quaternion rotation)
    {
        //cek jika dalam pool dictionary terdapat objek yg direquest
        if(!poolDictionary.ContainsKey(tag))
        {
            Debug.LogWarning("Object with tag" + tag + "doesn't exist");
            return null;
        }
        GameObject objectToSpawn = poolDictionary[tag].Dequeue();
        objectToSpawn.SetActive(true);
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;

        poolDictionary[tag].Enqueue(objectToSpawn);

        return objectToSpawn;
    }
}
