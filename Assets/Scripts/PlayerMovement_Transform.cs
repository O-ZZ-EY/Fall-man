using UnityEngine;

public class PlayerMovement_Transform : MonoBehaviour
{
    public float moveSpeed = 5f;               // Horizontal movement speed
    public float jumpHeight = 3f;              // Jump height
    public float fallSpeed = 3f;               // How quickly the player falls
    public float gravitySmoothness = 2f;       // Smooths the fall (higher = slower descent)
    public LayerMask groundLayer;              // Define what counts as "ground"
    public Transform groundCheck;              // Empty object at player's feet
    public float groundCheckRadius = 0.1f;     // Size of the ground check area

    private Vector2 velocity;
    private bool isGrounded = false;
    

    void Update()
    {
        HandleMovement();
        HandleJump();
        HandleFalling();
    }

    void HandleMovement()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        velocity.x = moveInput * moveSpeed;
        transform.position += new Vector3(velocity.x, 0f, 0f) * Time.deltaTime;
    }

    void HandleJump()
    {
        // Check ground using OverlapCircle (simple ground detection)
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(2 * jumpHeight * fallSpeed);
        }
    }

    void HandleFalling()
    {
        // Apply manual gravity with smooth control
        if (!isGrounded)
        {
            velocity.y -= fallSpeed * Time.deltaTime * gravitySmoothness;
        }
        else if (velocity.y < 0)
        {
            velocity.y = 0;
        }

        transform.position += new Vector3(0f, velocity.y, 0f) * Time.deltaTime;
    }

    void OnDrawGizmosSelected()
    {
        // Draw ground check radius in editor for easy tuning
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
    public enum PlayerState
    {
        GROUNDED,
        FALLING,
        JUMPING,
        ATTACKING,
        TAKEHIT,
        DEAD
    }  

    
}