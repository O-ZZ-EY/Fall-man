using UnityEngine;

public class RopeScript : MonoBehaviour
{
    public bool clicking = false;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            clicking = true;
        }
        if (Input.GetMouseButtonUp(0))
        {
            clicking = false;
        }
    }
    

    public void OnTriggerStay2D(Collider2D player)
    {
        if (player.gameObject.tag == "Player")
        {
            Rigidbody2D rigidBody = player.gameObject.GetComponent<Rigidbody2D>();

            if (clicking == true)
            {
                rigidBody.bodyType = RigidbodyType2D.Static;
            }
            else
            {
                rigidBody.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
