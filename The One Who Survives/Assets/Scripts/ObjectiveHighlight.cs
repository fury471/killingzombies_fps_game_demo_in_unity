using UnityEngine;

public class ObjectiveHighlight : MonoBehaviour
{
    public GameObject highlightObject;
    public string promptText = "Collect Objective";

    public void SetHighlighted(bool highlighted)
    {
        if (highlightObject != null)
        {
            highlightObject.SetActive(highlighted);
        }
    }
}
