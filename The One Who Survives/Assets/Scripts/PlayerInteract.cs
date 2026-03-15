using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    public Camera playerCamera;
    public float interactRange = 3f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            TryInteract();
        }
    }

    void TryInteract()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactRange))
        {
            DoorInteractable singleDoor = hit.collider.GetComponentInParent<DoorInteractable>();
            if (singleDoor != null)
            {
                singleDoor.ToggleDoor();
                return;
            }

            DoubleDoorInteractable doubleDoor = hit.collider.GetComponentInParent<DoubleDoorInteractable>();
            if (doubleDoor != null)
            {
                doubleDoor.ToggleDoor();
            }
        }
    }
}
