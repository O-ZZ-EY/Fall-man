using System.Collections;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{
    public float dashSpeed = 20f;  
    public float dashDuration = 0.15f;
    public float dashCooldown = 0.5f;

    private bool isDashing = false;
    private bool canDash = true;

    private Rigidbody2D rb;
    private Vector2 originalGravity;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        originalGravity = rb.gravityScale * Vector2.up; //Why times vector2up
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            TryDash();
        }
    }

    void TryDash()
    {
        if (!canDash || isDashing)
            return;

        StartCoroutine(DashRoutine());
    }

    IEnumerator DashRoutine()
    {
        isDashing = true;
        canDash = false;

        float storedGravity = rb.gravityScale;
        rb.gravityScale = 0f;

        float dashInput = Input.GetAxisRaw("Horizontal");
        if (dashInput == 0)
        {
            // If no input, dash in facing direction
            dashInput = transform.localScale.x > 0 ? 1 : -1;
        }

        float t = 0f;
        while (t < dashDuration)
        {
            rb.linearVelocity = new Vector2(dashInput * dashSpeed, 0);
            t += Time.deltaTime;
            yield return null;
        }

        rb.gravityScale = storedGravity;
        isDashing = false;

        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}