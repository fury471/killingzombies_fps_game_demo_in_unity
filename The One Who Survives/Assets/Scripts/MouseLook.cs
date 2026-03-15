using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public Transform playerBody;
    public float mouseSensitivity = 160f;
    public float lookSmoothTime = 0.03f;
    public float minPitch = -80f;
    public float maxPitch = 80f;

    private float currentPitch = 0f;
    private float targetPitch = 0f;
    private float currentYaw = 0f;
    private float targetYaw = 0f;
    private float pitchVelocity = 0f;
    private float yawVelocity = 0f;
    private float effectiveSensitivity = 2f;

    void Awake()
    {
        // Keep older scene values usable after switching away from deltaTime-scaled mouse input.
        effectiveSensitivity = mouseSensitivity > 20f ? mouseSensitivity * 0.01f : mouseSensitivity;

        if (playerBody != null)
        {
            currentYaw = playerBody.eulerAngles.y;
            targetYaw = currentYaw;
        }

        float localPitch = transform.localEulerAngles.x;

        if (localPitch > 180f)
        {
            localPitch -= 360f;
        }

        currentPitch = localPitch;
        targetPitch = currentPitch;
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * effectiveSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * effectiveSensitivity;

        targetYaw += mouseX;
        targetPitch -= mouseY;
        targetPitch = Mathf.Clamp(targetPitch, minPitch, maxPitch);
    }

    void LateUpdate()
    {
        currentYaw = Mathf.SmoothDampAngle(currentYaw, targetYaw, ref yawVelocity, lookSmoothTime);
        currentPitch = Mathf.SmoothDampAngle(currentPitch, targetPitch, ref pitchVelocity, lookSmoothTime);

        transform.localRotation = Quaternion.Euler(currentPitch, 0f, 0f);

        if (playerBody != null)
        {
            playerBody.rotation = Quaternion.Euler(0f, currentYaw, 0f);
        }
    }
}
