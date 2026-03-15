using UnityEngine;

public class KnifeAttack : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 2f;
    public int damage = 35;
    public float attackRate = 1f;
    public WeaponAnimationPlayer weaponAnimationPlayer;
    public AudioSource audioSource;
    public AudioClip swingClip;
    public AudioClip hitClip;

    private float nextAttackTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time >= nextAttackTime)
        {
            Attack();
            nextAttackTime = Time.time + 1f / attackRate;
        }
    }

    void Attack()
    {
        PlayClip(swingClip);

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (weaponAnimationPlayer != null)
        {
            weaponAnimationPlayer.PlayFire();
        }

        if (Physics.Raycast(ray, out hit, range))
        {
            EnemyHealth enemy = hit.collider.GetComponent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                PlayClip(hitClip);
            }
        }
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
