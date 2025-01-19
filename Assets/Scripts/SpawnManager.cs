using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnManager : MonoBehaviour
{
    public Transform[] spawnPoints;
    public static SpawnManager instance;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        if (instance != this)
        {
            Destroy(gameObject);
        }
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Transform GetRandomSpawnPoint()
    {
        return spawnPoints[Random.Range(0, spawnPoints.Length)];
    }
    
    
    
}
