using UnityEngine;

public class HomingBullet : MonoBehaviour
{
    public float speed = 4f; //Mess around with this to make it balanced
    public float rotateSpeed = 180f;
    public float lifeTime = 5f;

    private Transform player;

    void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        Vector2 direction = player.position - transform.position;
        direction = direction.normalized;

        float rotateAmount = Vector3.Cross(direction, transform.up).z;

        transform.Rotate(0f, 0f, -rotateAmount * rotateSpeed * Time.deltaTime);

        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    
}
