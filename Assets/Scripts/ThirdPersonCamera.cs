using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public Transform target; // Referensi ke CameraPivot
    public float mouseSensitivity = 5f;
    public float distanceFromTarget = 4f;
    public float verticalRotationLimit = 60f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        rotationY += mouseX;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -verticalRotationLimit, verticalRotationLimit);

        // Rotasi kamera di sekitar pivot
        transform.position = target.position - (Quaternion.Euler(rotationX, rotationY, 0) * Vector3.forward * distanceFromTarget);
        transform.LookAt(target);
    }
}
