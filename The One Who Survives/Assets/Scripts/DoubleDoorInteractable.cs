using UnityEngine;

public class DoubleDoorInteractable : MonoBehaviour
{
    public Transform leftDoor;
    public Transform rightDoor;
    public UnityEngine.AI.NavMeshObstacle navObstacle;

    public float leftOpenAngle = -120f;
    public float rightOpenAngle = 120f;
    public float openSpeed = 3f;
    public string promptText = "Press F to Open Door";
    public AudioSource audioSource;
    public AudioClip openClip;
    public AudioClip closeClip;

    private bool isOpen = true;

    private Quaternion leftClosedRotation;
    private Quaternion rightClosedRotation;
    private Quaternion leftOpenRotation;
    private Quaternion rightOpenRotation;

    void Start()
    {
        if (leftDoor != null)
        {
            leftClosedRotation = Quaternion.Euler(0f, 0f, 0f);
            leftOpenRotation = leftClosedRotation * Quaternion.Euler(0f, leftOpenAngle, 0f);
        }

        if (rightDoor != null)
        {
            rightClosedRotation = Quaternion.Euler(0f, 0f, 0f);
            rightOpenRotation = rightClosedRotation * Quaternion.Euler(0f, rightOpenAngle, 0f);
        }
        if (leftDoor.localRotation.y != 0f && rightDoor.localRotation.y != 0f)
        {
            isOpen = true;
        }
        else
        {
            isOpen = false;
        }
        SetObstacleState(!isOpen);
    }

    void Update()
    {
        if (leftDoor != null)
        {
            Quaternion leftTarget = isOpen ? leftOpenRotation : leftClosedRotation;
            leftDoor.localRotation = Quaternion.Slerp(leftDoor.localRotation, leftTarget, Time.deltaTime * openSpeed);
        }

        if (rightDoor != null)
        {
            Quaternion rightTarget = isOpen ? rightOpenRotation : rightClosedRotation;
            rightDoor.localRotation = Quaternion.Slerp(rightDoor.localRotation, rightTarget, Time.deltaTime * openSpeed);
        }
    }

    public void ToggleDoor()
    {
        isOpen = !isOpen;
        SetObstacleState(!isOpen);
        PlayClip(isOpen ? openClip : closeClip);
    }

    void SetObstacleState(bool blocked)
    {
        if (navObstacle != null)
        {
            navObstacle.enabled = blocked;
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

