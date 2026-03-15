using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public int medkitCount = 2;
    public int medkitHealAmount = 50;
    public AudioSource audioSource;
    public AudioClip hurtClip;
    public AudioClip medkitClip;

    void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            UseMedkit();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        PlayClip(hurtClip);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
    }

    void UseMedkit()
    {
        if (medkitCount <= 0)
        {
            return;
        }

        if (currentHealth >= maxHealth)
        {
            return;
        }

        currentHealth += medkitHealAmount;

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        medkitCount--;
        PlayClip(medkitClip);
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
