using UnityEngine;

public class PendulumController : MonoBehaviour
{
    public Transform pendulumArm;    // Reference to the pendulum arm
    public float damping = 0.99f;    // Damping factor to slow down the pendulum
    public float initialAngle = 30f; // Initial angle in degrees

    private Rigidbody rb;
    private HingeJoint hinge;

    void Start()
    {
        // Get components
        rb = GetComponentInChildren<Rigidbody>();
        hinge = pendulumArm.GetComponent<HingeJoint>();

        // Set the pendulum's initial position
        SetInitialPosition();
    }

    void FixedUpdate()
    {
        // Apply damping to slow down the pendulum
        if (rb != null)
        {
            rb.angularVelocity *= damping;
        }
    }

    public void SetInitialPosition()
    {
        // Calculate the initial rotation for the pendulum
        pendulumArm.localRotation = Quaternion.Euler(initialAngle, 0, 0);
    }
}
