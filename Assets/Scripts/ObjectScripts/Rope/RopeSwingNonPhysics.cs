using UnityEngine;

public class SimpleSwing : MonoBehaviour
{
    public float swingSpeed = 50f;   // speed of rotation
    public float maxAngle = 45f;     // maximum swing angle
    public Vector3 playerOffset = new Vector3(0f, 0.5f, 0f); // where player sits relative to rectangle

    private bool isGrabbing = false;
    private GameObject player;
    private float currentAngle = 0f;
    private float direction = 1f;

    void Update()
    {
        if (isGrabbing)
        {
            // Rotate rectangle
            float step = swingSpeed * Time.deltaTime * direction;
            currentAngle += step;

            if (Mathf.Abs(currentAngle) >= maxAngle)
            {
                direction *= -1f; // reverse swing
                currentAngle = Mathf.Clamp(currentAngle, -maxAngle, maxAngle);
            }

            transform.localRotation = Quaternion.Euler(0f, 0f, currentAngle);

            // Move player with rectangle
            if (player != null)
            {
                player.transform.position = transform.position + playerOffset;
            }

            // Release check
            if (Input.GetMouseButtonUp(0))
            {
                isGrabbing = false;
                player = null;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Input.GetMouseButton(0))
        {
            isGrabbing = true;
            player = other.gameObject;
        }
    }
}