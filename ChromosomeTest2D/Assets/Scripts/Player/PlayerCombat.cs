using UnityEngine;


public class PlayerCombat : MonoBehaviour
{
    private Animator anim;

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;

    public Transform attackPos;

    public float timeBetweenShots;

    private float shotTime;

    Collider2D[] hitEnemies;

    Animator cameraAnim;

    private void Start()
    {
        cameraAnim = Camera.main.GetComponent<Animator>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= shotTime)
            {
                cameraAnim.SetTrigger("shake");
                hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
                anim.SetTrigger("Attack");
                foreach (Collider2D enemy in hitEnemies)
                {
                    enemy.GetComponent<EnemyMovement>().TakeDamage(attackPos);
                }
                shotTime = Time.time + timeBetweenShots;

            }
        }
    }

    public void Attack()
    {


    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
            return;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

}
