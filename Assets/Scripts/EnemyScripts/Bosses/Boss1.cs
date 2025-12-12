using UnityEngine;

public class Boss1 : MonoBehaviour
{
    public float MaxHealth;
    public float CurrentHealth;

    void Start()
    {
        CurrentHealth = MaxHealth;
    }

    void JustParryBro(int damage)
    {
        CurrentHealth -= damage;
        if(CurrentHealth <= 0f)
        {
            Destroy(gameObject);
        }
        if (GameManager.instance.CurrentTimer < 20f)
        {
            
        }
    }
}
