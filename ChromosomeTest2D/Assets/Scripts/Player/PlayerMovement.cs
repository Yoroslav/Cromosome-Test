using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Animator anim;

    private Vector2 moveVector;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        moveVector.x = Input.GetAxisRaw("Horizontal");
        moveVector.y = Input.GetAxisRaw("Vertical");
        anim.SetFloat("Speed", Mathf.Abs(moveVector.magnitude));

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVector * moveSpeed * Time.fixedDeltaTime);

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            anim.SetTrigger("Hurt");
        }

    }
}

