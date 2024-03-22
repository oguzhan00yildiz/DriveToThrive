using UnityEngine;

public class CarCameraRotate : MonoBehaviour
{
    // Sensitivity for mouse movement
    public float sensitivity = 5.0f;
    public float turretRotationSpeed = 5.0f;

    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    [SerializeField] private Transform turretBarrel;
    private Rigidbody carRigidbody;

    // Offset for the turret rotation
    public Vector3 turretOffset = new Vector3(0f, 0f, 0f);

    void Start()
    {
        carRigidbody = transform.parent.GetComponent<Rigidbody>();
    }

    void Update()
    {
        RotateTheCamera();
        RotateTheTurret();
    }

    private void RotateTheCamera()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotationY += mouseX * sensitivity;
        rotationX -= mouseY * sensitivity;

        rotationX = Mathf.Clamp(rotationX, -35f, 35f);

        transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);
    }

    private void RotateTheTurret()
    {
        // Rotate the turret always towards the mouse position with offset
        Quaternion targetRotation = Quaternion.LookRotation(turretBarrel.position - Camera.main.transform.position + turretOffset);

        turretBarrel.rotation = targetRotation;
    }
}
