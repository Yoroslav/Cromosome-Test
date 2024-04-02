using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreEnemy : MonoBehaviour
{
    public int score;
    private ScoreManager scoreManager;

    public GameObject deathEffect;
    private UnityEngine.Object explosion;
    private UnityEngine.Object enemyRef;

    [SerializeField]
    float timeDestroy;

    Vector3 spawnPos;
    private void Start()
    {
        explosion = Resources.Load("Explosion");
        enemyRef = Resources.Load("Enemy");
        spawnPos = transform.position;

        scoreManager = FindAnyObjectByType<ScoreManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {

            score--;

            scoreManager.UpdateScoreText(score);
            Died();
        }
    }

    void Died()
    {
        GameObject explosionRef = (GameObject)Instantiate(explosion);
        explosionRef.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        gameObject.SetActive(false);

        Invoke("Respawn", timeDestroy);
    }

    void Respawn()
    {
        GameObject enemyCopy = (GameObject)Instantiate(enemyRef);
        enemyCopy.transform.position = new Vector3(Random.Range(spawnPos.x - 1, spawnPos.x + 1), Random.Range(spawnPos.y - 1, spawnPos.y + 1), spawnPos.z);

        Destroy(gameObject);
    }
}

