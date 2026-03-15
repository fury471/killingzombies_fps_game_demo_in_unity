using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target;
    public float detectionRange = 8f;
    public float attackRange = 1.5f;
    public int attackDamage = 10;
    public float attackCooldown = 1f;
    public AudioSource audioSource;
    public AudioClip alertClip;
    public AudioClip attackClip;

    private NavMeshAgent agent;
    private PlayerHealth playerHealth;
    private ZombieAnimationController zombieAnimationController;
    private EnemyHealth enemyHealth;
    private float nextAttackTime = 0f;
    private bool wasAlerted = false;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        enemyHealth = GetComponent<EnemyHealth>();
        zombieAnimationController = GetComponentInChildren<ZombieAnimationController>();
    }

    void Start()
    {
        if (target != null)
        {
            playerHealth = target.GetComponent<PlayerHealth>();
        }
    }

    void Update()
    {
        if (target == null || (enemyHealth != null && enemyHealth.IsDead))
        {
            return;
        }

        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        bool isAlerted = distanceToTarget <= detectionRange;
        bool isAttacking = distanceToTarget <= attackRange;

        if (isAlerted && !wasAlerted)
        {
            PlayClip(alertClip);
        }

        float moveSpeed = 0f;

        if (agent != null && agent.speed > 0f)
        {
            moveSpeed = agent.velocity.magnitude / agent.speed;
        }

        moveSpeed = Mathf.Clamp(moveSpeed, 0f, 1.5f);

        if (zombieAnimationController != null)
        {
            zombieAnimationController.SetAlerted(isAlerted);
            zombieAnimationController.SetAttacking(isAttacking);
            zombieAnimationController.SetMoveSpeed(moveSpeed);
        }

        if (!isAlerted)
        {
            agent.isStopped = true;
            wasAlerted = false;
            return;
        }

        if (!isAttacking)
        {
            agent.isStopped = false;
            agent.SetDestination(target.position);
        }
        else
        {
            agent.isStopped = true;

            if (playerHealth != null && Time.time >= nextAttackTime)
            {
                playerHealth.TakeDamage(attackDamage);
                PlayClip(attackClip);
                nextAttackTime = Time.time + attackCooldown;
            }
        }

        wasAlerted = isAlerted;
    }

    void PlayClip(AudioClip clip)
    {
        if (clip == null)
        {
            return;
        }

        if (audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
        else
        {
            AudioSource.PlayClipAtPoint(clip, transform.position);
        }
    }
}
