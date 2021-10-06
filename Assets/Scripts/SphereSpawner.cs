using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereSpawner : MonoBehaviour
{
    private GameObject[] pool;
    private int poolSize = 20;
    [SerializeField] GameObject sphere;
    private float spawnRange = 2f;
    private float ySpawnRange = 1f;
    private float spawnTimer = 1f;
    public int spawnedSpheres;

    private void Awake()
    {
        PopulatePool();
    }

    void Start()
    {
        spawnedSpheres = 0;
        StartCoroutine(SpawnSpheres());
    }

    private void PopulatePool()
    {
        pool = new GameObject[poolSize];
        for (int i = 0; i < pool.Length; i++)
        {
            Vector3 offset = new Vector3(Random.Range(-spawnRange, spawnRange), Random.Range(-ySpawnRange,ySpawnRange), Random.Range(-spawnRange, spawnRange));
            pool[i] = Instantiate(sphere, this.transform.position + offset, Quaternion.identity);
            pool[i].SetActive(false);
        }
    }

    IEnumerator SpawnSpheres()
    {
        foreach (GameObject sphere in pool)
        {
            sphere.SetActive(true);
            spawnedSpheres++;
            yield return new WaitForSeconds(spawnTimer);
        }
    }
}
