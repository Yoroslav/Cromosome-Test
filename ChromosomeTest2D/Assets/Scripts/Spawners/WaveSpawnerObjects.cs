using System.Collections;
using UnityEngine;

public class WaveSpawnerObjects : MonoBehaviour
{
    public float spawnRate = 1.0f;
    public float timeBetweenWaves = 3.0f;
    public Transform[] spawnPoints;
    public int chromosomeCount = 1;
    public GameObject chromosome;

    private bool waveIsDone = true;
    private Transform portal;

    private void Update()
    {
        if (chromosomeCount <= 5)
        {
            if (GameObject.FindGameObjectsWithTag("Chromosome").Length == 0 && waveIsDone)
            {
                StartCoroutine(WaveSpawner());
            }
        }
    }

    IEnumerator WaveSpawner()
    {
        waveIsDone = false;

        Transform randomPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(chromosome, randomPoint.position, Quaternion.identity);

        yield return new WaitForSecondsRealtime(timeBetweenWaves);

        waveIsDone = true;
    }

    public void SetPortal(Transform newPortal)
    {
        portal = newPortal;
        this.enabled = false;
    }
}

