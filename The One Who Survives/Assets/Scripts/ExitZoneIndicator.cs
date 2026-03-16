using UnityEngine;

public class ExitZoneIndicator : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject readyVisual;

    private bool lastReadyState = false;

    void Start()
    {
        SetReadyVisual(false);
    }

    void Update()
    {
        if (gameManager == null || readyVisual == null)
        {
            return;
        }

        bool isReady = gameManager.HasAllObjectives();

        if (isReady != lastReadyState)
        {
            SetReadyVisual(isReady);
            lastReadyState = isReady;
        }
    }

    void SetReadyVisual(bool isReady)
    {
        readyVisual.SetActive(isReady);
    }
}
