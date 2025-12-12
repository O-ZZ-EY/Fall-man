using UnityEngine;

public class Rocks : MonoBehaviour
{
    public float rockHealth = 100f;
    public float rockHealthCurrent;
    void Start()
    {
        rockHealthCurrent = rockHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        rockHealthCurrent -= damage;
        
        if(rockHealthCurrent <= 0f)
        {
            Destroy(gameObject);
        }
    }
}
