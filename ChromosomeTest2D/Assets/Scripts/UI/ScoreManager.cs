using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    public TMP_Text scoreText;

    public int numberOfChromosomes;
    public int maxNumberOfChromosomes;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    private void Update()
    {
        scoreText.text = $"Chromosomes: {numberOfChromosomes}";
    }

    public void UpdateScoreText(int score)
    {
        numberOfChromosomes += score;

    }
}