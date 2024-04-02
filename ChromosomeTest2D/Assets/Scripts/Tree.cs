using UnityEngine;

public class Tree : MonoBehaviour
{
    public Sprite newSprite;
    public Sprite oldSprite;

    private SpriteRenderer spriteRenderer;
    private bool playerInRange = false;
    public float detectionRadius = 2f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = oldSprite;
    }

    void Update()
    {
        float distanceToPlayer = Vector2.Distance(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position);

        if (distanceToPlayer <= detectionRadius)
        {
            playerInRange = true;
        }
        else
        {
            playerInRange = false;
        }

        if (playerInRange)
        {
            spriteRenderer.sprite = newSprite;
        }
        else
        {
            spriteRenderer.sprite = oldSprite;
        }
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}