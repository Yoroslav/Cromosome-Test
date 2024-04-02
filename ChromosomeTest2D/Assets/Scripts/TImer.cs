using TMPro;
using UnityEngine;

public class TImer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    [SerializeField] float initialTime = 60.0f;
    [SerializeField] public float remainingTime;

    private SceneTransitions sceneTransitions;

    private void Start()
    {
        sceneTransitions = FindObjectOfType<SceneTransitions>();

        ResetTimer();
    }

    private void Update()
    {
        if (remainingTime > 0)
        {
            UpdateTimer();
        }
        else
        {
            HandleTimerEnd();
        }
    }

    private void UpdateTimer()
    {
        remainingTime -= Time.deltaTime;

        if (remainingTime < 60)
        {
            timerText.color = Color.red;
        }

        UpdateTimerDisplay();
    }

    private void UpdateTimerDisplay()
    {
        int minutes = Mathf.FloorToInt(remainingTime / 60);
        int seconds = Mathf.FloorToInt(remainingTime % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    private void HandleTimerEnd()
    {
        remainingTime = 0;
        timerText.color = Color.red;

        if (sceneTransitions != null)
        {
            sceneTransitions.LoadScene("LOSE");
        }
    }

    public void ResetTimer()
    {
        remainingTime = initialTime;
        timerText.color = Color.white;  
    }
}
