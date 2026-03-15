using UnityEngine;

public class ZombieAnimationController : MonoBehaviour
{
    public Animator animator;

    public void SetAlerted(bool alerted)
    {
        if (animator != null)
        {
            animator.SetBool("IsAlerted", alerted);
        }
    }

    public void SetAttacking(bool attacking)
    {
        if (animator != null)
        {
            animator.SetBool("IsAttacking", attacking);
        }
    }

    public void SetMoveSpeed(float moveSpeed)
    {
        if (animator != null)
        {
            animator.SetFloat("MoveSpeed", moveSpeed);
        }
    }

    public void PlayDeath()
    {
        if (animator != null)
        {
            animator.SetTrigger("Die");
        }
    }
}
