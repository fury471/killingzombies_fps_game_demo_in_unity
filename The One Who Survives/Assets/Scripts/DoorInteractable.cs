using UnityEngine;
using UnityEngine.AI;

public class DoorInteractable : MonoBehaviour
{
    public Transform Door;
    public float openAngle = 90f;
    public float openSpeed = 3f;
    public NavMeshObstacle navObstacle;
    public string promptText = "Press F to Open Door";
    public AudioSource audioSource;
    public AudioClip openClip;
    public AudioClip closeClip;

    private bool isOpen = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (Door == null)
        {
            Door = transform;
        }
        closedRotation = Quaternion.Euler(0f, 0f, 0f);
        openRotation = Quaternion.Euler(
            Door.eulerAngles.x,
            openAngle,
            Door.eulerAngles.z
        );
        if (Door.eulerAngles.y == 0)
        {
            isOpen = false;
        }
        else
        {
            isOpen = true;
        }
        SetObstacleState(!isOpen);
    }

    void Update()
    {
        Quaternion targetRotation = isOpen ? openRotation : closedRotation;
        Door.localRotation = Quaternion.Slerp(Door.localRotation, targetRotation, Time.deltaTime * openSpeed);
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
