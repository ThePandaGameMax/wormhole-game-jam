using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WormSpawner : MonoBehaviour
{

    private Transform car;

    public float spawnEvery;

    ObjectPool objectPool;
    // Start is called before the first frame update
    void Start()
    {
        car = GameObject.Find("Car").GetComponent<Transform>();
        objectPool = ObjectPool.instance;
        InvokeRepeating("SpawnWithDelay", spawnEvery, spawnEvery);
    }

    void SpawnWithDelay()
    {
        objectPool.SpawnFromPool("worm");
    }
}
