using UnityEngine;
using TMPro;

public class ObjectiveLookHighlighter : MonoBehaviour
{
    public Camera playerCamera;
    public float highlightRange = 2.5f;
    public TextMeshProUGUI promptText;

    private ObjectiveHighlight currentHighlight;

    void Update()
    {
        UpdateHighlightAndPrompt();
    }

    void UpdateHighlightAndPrompt()
    {
        if (currentHighlight != null)
        {
            currentHighlight.SetHighlighted(false);
            currentHighlight = null;
        }

        if (promptText != null)
        {
            promptText.text = "";
        }

        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, highlightRange))
        {
            ObjectiveHighlight objective = hit.collider.GetComponentInParent<ObjectiveHighlight>();
            if (objective != null)
            {
                currentHighlight = objective;
                currentHighlight.SetHighlighted(true);

                if (promptText != null)
                {
                    promptText.text = objective.promptText;
                }

                return;
            }

            DoorInteractable singleDoor = hit.collider.GetComponentInParent<DoorInteractable>();
            if (singleDoor != null && promptText != null)
            {
                promptText.text = singleDoor.promptText;
                return;
            }

            DoubleDoorInteractable doubleDoor = hit.collider.GetComponentInParent<DoubleDoorInteractable>();
            if (doubleDoor != null && promptText != null)
            {
                promptText.text = doubleDoor.promptText;
            }
        }
    }
}
