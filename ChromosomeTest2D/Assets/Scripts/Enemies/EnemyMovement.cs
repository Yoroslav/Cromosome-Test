using Pathfinding;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Transform player;

    public float moveSpeed = 200f;
    public float nextWaypointDistance = 3f;

    Path path;
    int currentWaypoint = 0;
    bool reachedEndOfPath = false;

    Seeker seeker;

    private Rigidbody2D myBody;

    private float stopTime;
    public float startStopTime;
    private float normalSpeed;

    public Transform enemyGFX;
    private EnemyCollision enemyCollision;
    void Start()
    {
        normalSpeed = moveSpeed;
        seeker = GetComponent<Seeker>();
        player = GameObject.FindGameObjectWithTag("Player").transform;

        myBody = GetComponent<Rigidbody2D>();

        InvokeRepeating("UpdatePath", 0f, .5f);

        enemyCollision = GetComponent<EnemyCollision>();

    }

    void UpdatePath()
    {
        if (seeker.IsDone())
            seeker.StartPath(myBody.position, player.position, OnPathComplete);
    }
    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }
    void FixedUpdate()
    {
        if (stopTime <= 0)
        {
            moveSpeed = normalSpeed;
        }
        else
        {
            moveSpeed = 0;
            stopTime -= Time.deltaTime;
        }

        // Enemy AI

        if (path == null || path.vectorPath == null || path.vectorPath.Count == 0)
            return;

        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndOfPath = true;
        }
        else
        {
            reachedEndOfPath = false;
        }

        if (path == null || path.vectorPath == null || currentWaypoint >= path.vectorPath.Count)
            return;

        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - myBody.position).normalized;

        Vector2 force = direction * moveSpeed * Time.deltaTime;

        myBody.AddForce(force);

        float distance = Vector2.Distance(myBody.position, path.vectorPath[currentWaypoint]);

        if (distance < nextWaypointDistance)
        {
            currentWaypoint++;
        }

        if (force.x >= .01f)
        {
            enemyGFX.localScale = new Vector3(1, 1, 1);
        }
        else if (force.x <= -.01f)
        {
            enemyGFX.localScale = new Vector3(-1, 1, 1);
        }
    }

    public void TakeDamage(Transform attack)
    {
        stopTime = startStopTime;
        Vector2 pushDirection = (transform.position - attack.transform.position).normalized;
        enemyCollision.DamagePos(pushDirection);
    }


}
