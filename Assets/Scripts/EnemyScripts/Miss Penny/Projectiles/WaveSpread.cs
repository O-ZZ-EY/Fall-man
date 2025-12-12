using UnityEngine;

public class WaveSpread : MonoBehaviour
{
    public float speed = 5f;//Speed of bullets
    public float waveAmount = 5f;
    public float waveSpeed = 10f;//How often waves spawn
    public float lifeTime = 5f;

    private float timer = 0f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        float x = Mathf.Sin(timer * waveSpeed); //Q: Mathf.Sin???
        float y = speed * Time.deltaTime;

        transform.Translate(new Vector2(x, y * Time.deltaTime));
    }
}