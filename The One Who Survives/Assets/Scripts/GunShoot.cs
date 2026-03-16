using UnityEngine;

public class GunShoot : MonoBehaviour
{
    public Camera playerCamera;
    public float range = 100f;
    public int damage = 20;
    public float fireRate = 5f;

    public int currentAmmo = 30;
    public int magazineSize = 30;
    public int reserveAmmo = 60;
    public WeaponAnimationPlayer weaponAnimationPlayer;
    public AudioSource audioSource;
    public AudioClip fireClip;
    public AudioClip reloadClip;


    private float nextTimeToFire = 0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetMouseButton(0) && Time.time >= nextTimeToFire)
        {
            Shoot();
            nextTimeToFire = Time.time + 1f / fireRate;
        }
    }

    void Shoot()
    {
        if (currentAmmo <= 0)
        {
            return;
        }

        currentAmmo--;
        PlayClip(fireClip);

        if (weaponAnimationPlayer != null)
        {
            weaponAnimationPlayer.PlayFire();
        }

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, range, Physics.DefaultRaycastLayers, QueryTriggerInteraction.Ignore))
        {
            EnemyHealth enemy = hit.collider.GetComponentInParent<EnemyHealth>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
    }

    void Reload()
    {
        if (currentAmmo >= magazineSize)
        {
            return;
        }

        if (reserveAmmo <= 0)
        {
            return;
        }

        int neededAmmo = magazineSize - currentAmmo;
        int ammoToLoad = Mathf.Min(neededAmmo, reserveAmmo);

        currentAmmo += ammoToLoad;
        reserveAmmo -= ammoToLoad;
        PlayClip(reloadClip);

        if (weaponAnimationPlayer != null)
        {
            weaponAnimationPlayer.PlayReload();
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
