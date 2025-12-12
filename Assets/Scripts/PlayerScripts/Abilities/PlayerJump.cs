using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 12f;
    public int maxJumps = 2;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;
    
    public PlayerMovement_Transform playerMovement;
    private Rigidbody2D rb;
    private int jumpCount = 0;
    private bool isGrounded = false;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask groundLayer;
    public SpriteRenderer sprite;


    void Start()
    {
        playerMovement = GetComponent<PlayerMovement_Transform>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // Check if grounded
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        if (isGrounded && rb.linearVelocity.y <= 0)
        {
            jumpCount = 0;
        }
        
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < maxJumps)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f); // Reset vertical velocity for consistent jumps
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            jumpCount++;
        }

        if(isGrounded == false)
        {
            if (rb.linearVelocity.y < 0)
            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
                else if (rb.linearVelocity.y > 0 && !Input.GetKey(KeyCode.Space))
            {
                rb.linearVelocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

    }

    // Debug visualization for ground check
    void OnDrawGizmosSelected()
    {
        if (groundCheck == null)
            return; // Cannot draw without a reference

        // Choose color based on isGrounded
        //Application.IsPlaying checks to see if the game is running
        if (Application.isPlaying) // Only check isGrounded while the game is running
        {
            Gizmos.color = isGrounded ? Color.red : Color.green;
        }
        else
        {
            // Default color in editor before playing
            Gizmos.color = Color.yellow;
        }

        Gizmos.DrawWireSphere(groundCheck.position, groundCheckRadius);
    }
}