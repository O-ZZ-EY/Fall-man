using UnityEngine;

public class AttackHitBox : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Boss")
        {
            Boss1 bossHealth = other.gameObject.GetComponent<Boss1>();

            if (bossHealth != null)
            {
                //bossHealth.JustParryBro();
                Debug.Log("Boss took Damage");
            }
        }
    }
}


