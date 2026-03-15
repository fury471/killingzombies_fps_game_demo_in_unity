using UnityEngine;

public class ExitZone : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerHealth>() == null)
        {
            return;
        }

        if (gameManager != null && gameManager.HasAllObjectives())
        {
            gameManager.WinGame();
        }
    }
}
