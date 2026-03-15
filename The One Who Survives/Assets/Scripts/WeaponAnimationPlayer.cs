using UnityEngine;

public class WeaponAnimationPlayer : MonoBehaviour
{
    public Animator animator;
    public string fireStateName = "Rifle_Fire";
    public string reloadStateName = "Rifle_Reload";

    public void PlayFire()
    {
        if (animator != null)
        {
            animator.Play(fireStateName, 0, 0f);
        }
    }

    public void PlayReload()
    {
        if (animator != null)
        {
            animator.Play(reloadStateName, 0, 0f);
        }
    }
}
