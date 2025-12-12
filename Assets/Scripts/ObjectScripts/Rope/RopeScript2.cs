using UnityEngine;

public class RopeScript2 : MonoBehaviour
{
    private bool playerInside = false;
    private Rigidbody2D playerRb;

    void Update()
    {
        if (playerInside == true && playerRb != null)
        {
            if (Input.GetMouseButton(0))
            {
                playerRb.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                playerRb.bodyType = RigidbodyType2D.Dynamic;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = true;
            playerRb = other.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            playerInside = false;
            //If I have a valid player rb in my trigger
            if (playerRb != null)
            {
                playerRb.bodyType = RigidbodyType2D.Dynamic;
            }
            //There is no player inside of the rope collider anymore
            playerRb = null;
        }
    }
}