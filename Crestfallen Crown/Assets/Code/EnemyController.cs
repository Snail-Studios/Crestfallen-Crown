using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    [SerializeField] private float retreatSpeed = 1.5f;
    [SerializeField] private float stopRadius = 2f;
    [SerializeField] private float closeDistanceThreshold = 1f;
    [SerializeField] private float circleSpeed = 1.0f;

    [SerializeField] private Jab_Atk JATK;

    public LayerMask enemyLayer;
    public bool circle;

    private GameObject player;
    private Vector2 lastKnownPlayerPosition;
    private bool hasLineOfSight = false;
    private Rigidbody2D rb;
    public int HP;
    private Animator anim;

    // Attack variables
    [SerializeField] private float attackCooldown = 2f; // Adjust the cooldown as needed
    private float timeSinceLastAttack = 0f;

    public float invinsCooldown = 2.0f; // Adjust the cooldown as needed
    private float timeSinceLastDMG = 0f;

    private bool CanDMG()
    {
        // Check if enough time has passed since the last attack
        return timeSinceLastDMG >= invinsCooldown;
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        JATK = GetComponentInChildren<Jab_Atk>();
        circleSpeed = Random.Range(3, -3);
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        timeSinceLastDMG += Time.deltaTime;

        UpdateLineOfSight();

        if (Mathf.Abs(circleSpeed) <= 1)
        {
            circleSpeed = Random.Range(3, -3);
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distanceToPlayer < closeDistanceThreshold)
        {
            Debug.Log("Enemy is too close to the player!");
            Physics2D.IgnoreLayerCollision(9, 9, false);
            MoveTowardsTarget(player.transform.position, -retreatSpeed);
        }
        else if (hasLineOfSight && distanceToPlayer > stopRadius)
        {
            Physics2D.IgnoreLayerCollision(9, 9, false);
            MoveTowardsTarget(player.transform.position, speed);
        }
        else if (lastKnownPlayerPosition != Vector2.zero && hasLineOfSight)
        {
            if (circle)
            {
                Physics2D.IgnoreLayerCollision(9, 9, true);
                CirclePlayer();
            }
            else
            {
                Physics2D.IgnoreLayerCollision(9, 9, false);
                StopMoving();
                if (timeSinceLastAttack >= attackCooldown)
                {
                    Attack();
                }
            }
        }
        else if (lastKnownPlayerPosition != Vector2.zero)
        {
            Physics2D.IgnoreLayerCollision(9, 9, false);
            MoveTowardsTarget(lastKnownPlayerPosition, speed);
        }

        // Update attack cooldown timer
        timeSinceLastAttack += Time.deltaTime;
        //JATK.RotateTowardsPlayer(lastKnownPlayerPosition);
    }

    private void FixedUpdate()
    {
        UpdateLineOfSight();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("hitSMTH");
        circleSpeed = -circleSpeed;

        if (circle && timeSinceLastAttack >= attackCooldown)
        {
            Attack();
        }
    }

    private void UpdateLineOfSight()
    {
        int layerMask = 1 << 9;
        layerMask = ~layerMask;

        RaycastHit2D ray = Physics2D.Raycast(transform.position, player.transform.position - transform.position, Mathf.Infinity, layerMask);
        hasLineOfSight = ray.collider != null && ray.collider.CompareTag("Player");

        Debug.DrawRay(transform.position, player.transform.position - transform.position, hasLineOfSight ? Color.green : Color.red);

        if (hasLineOfSight)
        {
            lastKnownPlayerPosition = player.transform.position;
        }
    }

    private void MoveTowardsTarget(Vector2 targetPosition, float speed)
    {
        Physics2D.IgnoreLayerCollision(9, 9, false);
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = moveDirection * speed;

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            StopMoving();
        }
    }

    private void CirclePlayer()
    {
        Physics2D.IgnoreLayerCollision(9, 9);
        Vector2 circleDirection = new Vector2(lastKnownPlayerPosition.y - transform.position.y, transform.position.x - lastKnownPlayerPosition.x).normalized;
        rb.velocity = circleDirection * circleSpeed;

        if (timeSinceLastAttack >= attackCooldown)
        {
            Attack();
        }
    }

    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }

    private void Attack()
    {
        timeSinceLastAttack = 0f;
        anim.Play("Attack");
        //anim.gameObject.transform.position = new Vector3(0, 0, 0);
        Debug.Log("Attack");
    }

    public void TakeDamage(int damage)
    {
        if (CanDMG())
        {
            HP -= damage;
            Debug.Log("DMG");
            timeSinceLastDMG = 0;
        }

        if (HP <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);
    }
}
