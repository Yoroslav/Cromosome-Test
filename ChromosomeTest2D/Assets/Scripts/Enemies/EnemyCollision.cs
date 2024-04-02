using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    public float pushForce = 10f;

    private Animator anim;
    private Rigidbody2D rb;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Vector2 pushDirection = (transform.position - collision.transform.position).normalized;
            rb.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
            anim.SetTrigger("Hurt");
        }
    }

    public void DamagePos(Vector2 pos)
    {
        rb.AddForce(pos * pushForce, ForceMode2D.Impulse);

    }
}
