using UnityEngine;

public class SpaceshipControl : MonoBehaviour
{
    [SerializeField] Rigidbody rb; // Reference to the spaceship's Rigidbody
    [Space(5)]
    [SerializeField] float moveSpeed = 55f; // Speed for moving forward
    [SerializeField] float rotationSpeed = 5f; // Speed for rotating the spaceship

    void FixedUpdate()
    {
        // Move forward when Left Shift is pressed
        if (Input.GetKey(KeyCode.LeftShift))
            rb.AddForce(transform.forward * moveSpeed, ForceMode.Force);

        // Get rotation inputs for this frame
        float pitch = Input.GetAxis("Vertical") * rotationSpeed; // Pitch (X-axis) from vertical input
        float yaw = Input.GetAxis("Horizontal") * rotationSpeed; // Yaw (Y-axis) from horizontal input
        float roll = 0f; // Roll (Z-axis) starts at zero
        if (Input.GetKey(KeyCode.Q)) roll = rotationSpeed; // Roll right with Q key
        if (Input.GetKey(KeyCode.E)) roll = -rotationSpeed; // Roll left with E key

        // Apply torque for rotation on each axis
        rb.AddRelativeTorque(pitch, yaw, roll, ForceMode.Force);
    }
}