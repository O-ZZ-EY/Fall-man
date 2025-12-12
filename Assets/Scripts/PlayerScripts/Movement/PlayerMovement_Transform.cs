using UnityEngine;

public class PlayerMovement_Transform : MonoBehaviour
{
    public float moveSpeed = 5f;              
    public float jumpHeight = 9f;             
    public float fallSpeed = 3f;   
    public float horizontalMoveInput;            
    public float gravitySmoothness = 2f;       
    public LayerMask groundLayer;              
    public Transform groundCheck;              
    public float groundCheckRadius = 0.1f;     

    [Header("Potency")]
    public float potencyMeterCurrent;
    public float potencyMeter = 0f;
    public float maxPotency = 100f;

    private Vector2 velocity;
    private bool isGrounded = false;

    public SpriteRenderer spriteR;
    public Sprite Falling;
    public Sprite NotFalling;
    public Rigidbody2D rb;

    void Start()
    {
        potencyMeterCurrent = potencyMeter;
        spriteR = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        ReadMovement();
        HandleJump();
    }
    void FixedUpdate()
    {
        HandleGround();
        IncreasePotency();
        HandleFalling();
        HandleMovement();
        HandleObstacleCollision();
    }

    void ReadMovement()
    {
        horizontalMoveInput = Input.GetAxisRaw("Horizontal");
    }
    void HandleMovement()
    {
        velocity.x = horizontalMoveInput * moveSpeed;
        //transform.position += new Vector3(velocity.x, 0f, 0f) * Time.fixedDeltaTime;
        rb.MovePosition(transform.position + (Vector3)velocity * Time.fixedDeltaTime);
        //rb.MovePosition(transform.position + new Vector3(velocity.x, 0f, 0f) * Time.fixedDeltaTime);
    }

    void HandleJump()
    {
        // Check ground using OverlapCircle (simple ground detection)

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(2 * jumpHeight * fallSpeed);
        }
    }

    void HandleGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
    }

    void IncreasePotency()
    {
        potencyMeterCurrent += 2f * Time.fixedDeltaTime;
        if(potencyMeterCurrent > maxPotency)
        {
            potencyMeterCurrent = maxPotency;
        }
        GameManager.instance.potencyMeterCurrent = potencyMeterCurrent;
    }

    void HandleFalling()
    {
        // Apply manual gravity with smooth control
        if (!isGrounded)
        {
            spriteR.sprite = Falling;
            velocity.y -= fallSpeed * Time.fixedDeltaTime * gravitySmoothness;
            Debug.Log("In air");
        }
        else
        {
            Debug.Log("Grounded");
            if(velocity.y < 0)
            {
                spriteR.sprite = NotFalling;
                velocity.y = 0;
            }
        }
    }
    void HandleObstacleCollision()
    {
        if(potencyMeterCurrent < 100)
        {
            //Do Something
        }
    }
        
        // float potencyMultiplier = Mathf.Lerp(1f, 2f, potencyMeterCurrent / maxPotency);

        // if (velocity.y < 0)
        // {
        //     velocity.y *= potencyMultiplier; 

        // }

        //float maxFallSpeed = -20f; // you can change this

        //if (velocity.y < maxFallSpeed)
        //{
            //velocity.y = maxFallSpeed;

        //}

        //transform.position += new Vector3(0f, velocity.y, 0f) * Time.fixedDeltaTime;
        //rb.MovePosition(transform.position + new Vector3(0f, velocity.y, 0f) * Time.fixedDeltaTime);
    

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


    