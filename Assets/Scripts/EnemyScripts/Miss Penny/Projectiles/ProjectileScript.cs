using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float lifeTime = 10f;

    public Vector2 direction = Vector2.up;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(direction * bulletSpeed * Time.deltaTime);
    }
}
