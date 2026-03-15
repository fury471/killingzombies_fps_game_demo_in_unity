using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float crouchSpeed = 2.5f;
    public float gravity = -9.81f;
    public float jumpHeight = 1.2f;
    public float movementSmoothTime = 0.08f;
    public float crouchTransitionSpeed = 12f;

    public float standingHeight = 2f;
    public float crouchingHeight = 1f;

    public Transform playerCamera;
    public float standingCameraY = 0.8f;
    public float crouchingCameraY = 0.4f;
    public AudioSource movementAudioSource;
    public AudioClip movementClip;
    public float movementVolume = 0.2f;
    public float walkPitch = 1f;
    public float crouchPitch = 0.8f;

    private CharacterController controller;
    private Vector3 velocity;
    private Vector3 currentMoveVelocity;
    private Vector3 moveVelocityRef;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        bool isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0f)
        {
            velocity.y = -2f;
        }

        bool isCrouching = Input.GetKey(KeyCode.LeftControl);

        float currentSpeed = isCrouching ? crouchSpeed : moveSpeed;
        float targetHeight = isCrouching ? crouchingHeight : standingHeight;

        controller.height = Mathf.Lerp(controller.height, targetHeight, Time.deltaTime * crouchTransitionSpeed);

        if (playerCamera != null)
        {
            Vector3 camPos = playerCamera.localPosition;
            float targetCameraY = isCrouching ? crouchingCameraY : standingCameraY;
            camPos.y = Mathf.Lerp(camPos.y, targetCameraY, Time.deltaTime * crouchTransitionSpeed);
            playerCamera.localPosition = camPos;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        bool isMoving = Mathf.Abs(x) > 0.01f || Mathf.Abs(z) > 0.01f;

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        Vector3 desiredMove = (transform.right * x + transform.forward * z).normalized * currentSpeed;
        currentMoveVelocity = Vector3.SmoothDamp(
            currentMoveVelocity,
            desiredMove,
            ref moveVelocityRef,
            movementSmoothTime
        );

        Vector3 finalMove = currentMoveVelocity;
        finalMove.y = velocity.y;

        controller.Move(finalMove * Time.deltaTime);
        UpdateMovementAudio(isGrounded, isMoving, isCrouching);
    }

    void UpdateMovementAudio(bool isGrounded, bool isMoving, bool isCrouching)
    {
        if (movementAudioSource == null || movementClip == null)
        {
            return;
        }

        bool shouldPlay = isGrounded && isMoving;

        if (!shouldPlay)
        {
            if (movementAudioSource.isPlaying)
            {
                movementAudioSource.Stop();
            }

            return;
        }

        movementAudioSource.clip = movementClip;
        movementAudioSource.loop = true;
        movementAudioSource.volume = movementVolume;
        movementAudioSource.pitch = isCrouching ? crouchPitch : walkPitch;

        if (!movementAudioSource.isPlaying)
        {
            movementAudioSource.Play();
        }
    }
}
