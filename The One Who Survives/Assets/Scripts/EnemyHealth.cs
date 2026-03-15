using UnityEngine;
using UnityEngine.AI;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 60;
    public int currentHealth = 60;
    public AudioClip deathClip;

    private ZombieAnimationController zombieAnimationController;
    private EnemyAI enemyAI;
    private NavMeshAgent agent;
    private Collider[] allColliders;
    private bool isDead = false;

    public bool IsDead
    {
        get { return isDead; }
    }

    void Awake()
    {
        enemyAI = GetComponent<EnemyAI>();
        agent = GetComponent<NavMeshAgent>();
        allColliders = GetComponentsInChildren<Collider>();
    }

    void Start()
    {
        currentHealth = maxHealth;
        zombieAnimationController = GetComponentInChildren<ZombieAnimationController>();
    }

    public void TakeDamage(int damage)
    {
        if (isDead)
        {
            return;
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        if (enemyAI != null)
        {
            enemyAI.enabled = false;
        }

        if (agent != null)
        {
            agent.isStopped = true;
            agent.enabled = false;
        }

        foreach (Collider col in allColliders)
        {
            col.enabled = false;
        }

        if (zombieAnimationController != null)
        {
            zombieAnimationController.PlayDeath();
        }

        if (deathClip != null)
        {
            AudioSource.PlayClipAtPoint(deathClip, transform.position);
        }

        Destroy(gameObject, 2f);
    }
}
