using UnityEngine;
using UnityEngine.SceneManagement;

public class LozeMenu : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene(0);
    }
}
