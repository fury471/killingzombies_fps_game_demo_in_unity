using UnityEngine;

public class CollectibleItem : MonoBehaviour
{
    public enum CollectibleType
    {
        Medicine,
        File
    }

    public CollectibleType collectibleType;
    public GameManager gameManager;
    public AudioClip pickupClip;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() == null)
        {
            return;
        }

        if (gameManager == null)
        {
            return;
        }

        if (collectibleType == CollectibleType.Medicine)
        {
            gameManager.CollectMedicine();
        }
        else
        {
            gameManager.CollectFile();
        }

        if (pickupClip != null)
        {
            AudioSource.PlayClipAtPoint(pickupClip, transform.position);
        }

        Destroy(gameObject);
    }
}
