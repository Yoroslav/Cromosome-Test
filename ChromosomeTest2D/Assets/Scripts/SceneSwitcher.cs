using UnityEngine;

public class SceneSwitcher : MonoBehaviour
{
    public string nextSceneName;
    public SceneTransitions transitions;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Collider2D collider = Physics2D.OverlapPoint(clickPosition);


            if (collider != null && collider.gameObject == gameObject)
            {
                transitions.LoadScene(nextSceneName);
            }
        }
    }
}
