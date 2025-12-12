using UnityEngine;

public class FallingAttack : MonoBehaviour
{
    public Collider2D FallingAttackHitbox;
    public float Fallingdamage = 100f;


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            Rocks rocksHealth = other.gameObject.GetComponent<Rocks>();

            if (rocksHealth != null)
            {
                rocksHealth.TakeDamage(Fallingdamage);
                Debug.Log("Obstacle took Damage");
            }
        }
    }
}
