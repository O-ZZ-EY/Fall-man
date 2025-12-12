using UnityEngine;

public class RopeGrab : MonoBehaviour
{
    [Header("Swing Settings")]
    private bool playerInside = false;
    private bool isGrabbing = false;
    private Rigidbody2D playerRb;
    private HingeJoint2D playerJoint;
    public PlayerMovement_Rigidbody playerScript;

    void Update()
    {
        if (playerInside && playerRb != null)
        {
            // Grab rope on click
            if (Input.GetMouseButtonDown(0) && !isGrabbing)
            {
                GrabRope();
            }

            // Release rope on release
            if (isGrabbing && Input.GetMouseButtonUp(0))
            {
                ReleaseRope();
            }

            if (isGrabbing)
            {
                float moveInput = Input.GetAxis("Horizontal");
                // Apply a small horizontal force to swing naturally
                Vector2 force = new Vector2(moveInput, 0f);
                playerRb.AddForce(force);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            playerRb = other.GetComponent<Rigidbody2D>();
            playerScript = other.GetComponent<PlayerMovement_Rigidbody>();
        }


    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;

            if (isGrabbing)
            {
                ReleaseRope();
            }

            playerRb = null;
        }
    }

    void GrabRope()
    {
        if (playerRb == null) return;

        // Reset velocity to prevent bouncing
        playerRb.linearVelocity = Vector2.zero;
        playerRb.angularVelocity = 0f;

        // Keep Rigidbody Dynamic for physics
        // Add hinge joint
        playerJoint = playerRb.gameObject.AddComponent<HingeJoint2D>();
        playerJoint.connectedBody = GetComponent<Rigidbody2D>();
        playerJoint.autoConfigureConnectedAnchor = true;
        playerJoint.enableCollision = true;

        playerScript.moveSpeed = 20;

        isGrabbing = true;
    }

    void ReleaseRope()
    {
        if (playerJoint != null)
        {
            Destroy(playerJoint);
            playerJoint = null;
        }

        isGrabbing = false;
    }
}