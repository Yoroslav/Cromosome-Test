using UnityEngine;

public class Chromosome : MonoBehaviour
{
    public int score;

    private ScoreManager scoreManager;

    private void Start()
    {
        scoreManager = GetComponent<ScoreManager>();
        if (scoreManager == null)
        {
            scoreManager = GameObject.FindObjectOfType<ScoreManager>();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Collect();
        }
    }

    void Collect()
    {
        Destroy(gameObject);

        if (scoreManager != null && scoreManager.numberOfChromosomes <= scoreManager.maxNumberOfChromosomes)
        {
            score++;
        }
        else
        {
            score--;
        }

        if (scoreManager != null)
        {
            ScoreManager.Instance.UpdateScoreText(score);
        }
    }
}
