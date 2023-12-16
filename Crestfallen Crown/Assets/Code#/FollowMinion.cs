using UnityEngine;

public class FollowMinion : MonoBehaviour
{
    public Transform EnemyTarget;
    public Transform targetTransform;
    public float followSpeed = 5f;
    public float stoppingDistance = 2f;
    public float attackRange = 5f;
    Rigidbody2D rb;
    bool ISENEM;

    public float attackCooldown = 2.0f; // Adjust the cooldown as needed
    private float timeSinceLastAttack = 0f;

    bool CanAttack()
    {
        // Check if enough time has passed since the last attack
        return timeSinceLastAttack >= attackCooldown;
    }

    private void Start()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, 0);
        rb = GetComponent<Rigidbody2D>();
        if (targetTransform == null)
        {
            targetTransform = GameObject.FindWithTag("Player").transform;
        }
    }

    void Update()
    {

       
        GameObject[] minioncount = GameObject.FindGameObjectsWithTag("Minion");
        int minionnumber = minioncount.Length;

        if(minionnumber >= 3)
        {
            GameObject newestObject = minioncount[0];
            foreach (GameObject obj in minioncount)
            {
                if (obj.GetComponent<FollowMinion>().timeSinceLastAttack > newestObject.GetComponent<FollowMinion>().timeSinceLastAttack)
                {
                    newestObject = obj;
                }
            }

            // Destroy the newest object
            Destroy(newestObject);
        }

        if(targetTransform == null)
        {
            targetTransform = GameObject.FindWithTag("Player").transform;
        }

        timeSinceLastAttack += Time.deltaTime;

        if (targetTransform == null)
        {
            Debug.LogError("Target transform not set!");
            return;
        }

        float distancetoPlayer = Vector3.Distance(transform.position, GameObject.FindWithTag("Player").transform.position);

        float distanceToTarget = Vector3.Distance(transform.position, targetTransform.position);

        if (distanceToTarget > stoppingDistance)
        {
            float tooCloseDistance = 1.0f; // Adjust this distance as needed

            if (distanceToTarget > tooCloseDistance)
            {
                MoveTowardsTarget(targetTransform.position, followSpeed);
            }
        }
        else if (distanceToTarget <= stoppingDistance)
        {
            StopMoving();
        }

        if (distancetoPlayer >= 10)
        {
            targetTransform = GameObject.FindWithTag("Player").transform;
            ISENEM = false;
        }

        // Check for enemies in attack range
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, attackRange);
        foreach (Collider2D collider in hitColliders)
        {
            if (collider.CompareTag("Enemy"))
            {
                // Attack the enemy only if attack conditions are met
                if (CanAttack())
                {
                    AttackEnemy(collider.gameObject);
                }
                return; // Exit the loop after the first enemy is detected
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }

    void AttackEnemy(GameObject enemy)
    {
        MoveTowardsTarget(enemy.transform.position, followSpeed);
        targetTransform = enemy.transform;
        ISENEM = true;
        Debug.Log("Attacking enemy: " + enemy.name);
        GetComponentInChildren<Animator>().Play("Attack");
        timeSinceLastAttack = 0;
    }

    private void MoveTowardsTarget(Vector2 targetPosition, float speed)
    {
        Vector2 moveDirection = (targetPosition - (Vector2)transform.position).normalized;
        rb.velocity = moveDirection * speed;

        float distanceToTarget = Vector2.Distance(transform.position, targetPosition);
        if (distanceToTarget < 0.1f)
        {
            StopMoving();
        }
    }

    private void StopMoving()
    {
        rb.velocity = Vector2.zero;
    }
}
