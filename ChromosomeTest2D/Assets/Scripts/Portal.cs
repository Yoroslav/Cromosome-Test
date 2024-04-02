using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    private SceneTransitions sceneTransitions;
    [SerializeField] string nameScene = "Win";
    [SerializeField] float timerNextToScene = 5;

    private GameObject player;
    private Collider2D playerCollider;
    private SpriteRenderer sprite;
    private PlayerCombat playerCombat;
    private PlayerMovement playerMovement;

    [Header("DOTween")]
    public float rotationAngle = 360f;
    public float rotationDuration = 1f;

    public Vector3 targetScale = new Vector3(0f, 0f, 0f);
    public float shrinkDuration = 1f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        sceneTransitions = FindObjectOfType<SceneTransitions>();

        playerCollider = player.GetComponent<Collider2D>();
        playerCombat = player.GetComponent<PlayerCombat>();
        playerMovement = player.GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartAnimation();
            DisablePlayerComponents();
        }
    }

    void StartAnimation()
    {
        player.transform.DORotate(new Vector3(0, 0, rotationAngle), rotationDuration, RotateMode.FastBeyond360)
            .SetEase(Ease.Linear); 

        player.transform.DOScale(targetScale, shrinkDuration)
            .SetEase(Ease.InOutQuad) 
            .OnUpdate(NextScene);

    }

    public void NextScene()
    {
        if (player.transform.localScale == Vector3.zero)
            sceneTransitions.LoadScene(nameScene);
    }

    private void DisablePlayerComponents()
    {
            playerCollider.enabled = false;
            playerCombat.enabled = false;
            playerMovement.enabled = false;
    }
}
