using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPortal : MonoBehaviour
{
    public GameObject portalPrefab;
    public Transform[] spawnPoints;
    private TImer timer;  
    private bool hasSpawned;  

    private void Start()
    {
        timer = FindObjectOfType<TImer>();
    }

    private void Update()
    {
        if (timer.remainingTime <= 60 && !hasSpawned)
        {
            Spawn();
            hasSpawned = true;
        }
    }

    void Spawn()
    {
        if (spawnPoints.Length > 0) 
        {
            Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(portalPrefab, randomPoint.position, Quaternion.identity);
        }
    }
}
