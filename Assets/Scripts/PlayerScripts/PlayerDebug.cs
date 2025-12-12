using UnityEngine;

// This script provides live debug information for the player.
public class PlayerDebug : MonoBehaviour
{
    [Header("References")]
    public Rigidbody2D rb;

    [Header("Velocity")]
    public Vector2 velocityVector;
    public float horizontalSpeed;
    public float verticalSpeed;
    public float totalSpeed;

    [Header("Angular")]
    public float angularVelocity;

    [Header("State & Input")]
    public bool isGrounded;
    public bool isAttacking;
    public bool isDashing;
    public bool isTakingHit;
    public bool isDead;

    public bool inputJump;
    public bool inputDash;
    public Vector2 inputMovement;

    [Header("Other Debug")]
    public Vector2 lastHitPosition;

    public float timer;

    // Optional: reference your player state enum
    public enum PlayerState { GROUNDED, ATTACKING, TAKEHIT, DEAD, DASHING }
    public PlayerState currentState;

    void Update()
    {
        if (rb != null)
        {
            timer += Time.deltaTime;
            // Velocity
            velocityVector = rb.linearVelocity;
            horizontalSpeed = velocityVector.x;
            verticalSpeed = velocityVector.y;
            totalSpeed = velocityVector.magnitude;

            // Angular velocity
            angularVelocity = rb.angularVelocity;
        }

        // Input
        inputJump = Input.GetKey(KeyCode.Space) || (Input.touchCount > 0);
        inputDash = Input.GetKey(KeyCode.LeftShift) || (Input.touchCount > 1);
        inputMovement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // Grounded - check if touches > 0 (depends on your movement script)
        isGrounded = rb.IsTouchingLayers(LayerMask.GetMask("Ground"));

        // Example state tracking
        // You should update these booleans from your PlayerController
        // For demo purposes, just assign manually
        // isAttacking = playerController.isAttacking;
        // isDashing = playerController.isDashing;
        // isTakingHit = playerController.isTakingHit;
        // isDead = playerController.isDead;

        // Optional: record last hit position - you must update this when taking damage
    }

    //How to use:
    // Attach the script to your player gameobject
    // Drag the rigidbody of the player to the rb field and BOOM
}
