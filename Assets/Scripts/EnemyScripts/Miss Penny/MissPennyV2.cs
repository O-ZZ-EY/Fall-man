using System.Collections;
using UnityEngine;

public class MissPennyV2 : MonoBehaviour
{

    [Header("References")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform player;

    [Header("floats")]
    public float shootInterval = 1.5f;
    private float timer = 0f;
    float spiralAngle = 0f;
    public float speed;

    public bool BossFight;
    public bool flip;

    public enum PlayerDetected
    {
        PlayerInZone,
        PlayerOutOfZone,
    }

    void Update()
    {
        timer = timer + Time.deltaTime;

        if (timer >= shootInterval)
        {
            ShootRain();

            timer = 0f;
        }
    }

    void FixedUpdate()
    {
        Vector3 scale = transform.localScale;

        if (BossFight == true)
        {
            if (player.transform.position.x > transform.position.x)
            {
                Debug.Log("Boss is moving?");
                scale.x = Mathf.Abs(scale.x) * (flip ? -1 : 1);
                transform.Translate(x: speed * Time.deltaTime, y: 0, z: 0);
            }
            else
            {
                scale.x = Mathf.Abs(scale.x) * -1 * (flip ? -1 : 1);
                transform.Translate(x: speed * Time.deltaTime * -1, y: 0, z: 0);
            }
            transform.localScale = scale;
            transform.position = Vector3.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }   
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            BossFight = true;
            BossBehavior(PlayerDetected.PlayerInZone);
        }
        else
        {
            BossBehavior(PlayerDetected.PlayerOutOfZone);
        }
        
    }

    public void BossBehavior(PlayerDetected player)
    {
        if(player == PlayerDetected.PlayerInZone)
        {
            Debug.Log("Player in da zone");
        }
        else if(player == PlayerDetected.PlayerOutOfZone)
        {
            Debug.Log("Player NOT in da zone");
        }
    }

    void SpawnBullet(Vector2 direction)
    {
        GameObject newBullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        ProjectileScript bulletScript = newBullet.GetComponent<ProjectileScript>();
        bulletScript.direction = direction.normalized; //??
        
    }

    void ShootStraight()
    {
        SpawnBullet(Vector2.up);
    }
    
    void ShootSpread5() //Spawns bullets at the same time slightly apart from each other, in this case 5 of them
    {
        SpawnBullet(new Vector2(0f, 1f));
        SpawnBullet(new Vector2(-0.25f, 1f));
        SpawnBullet(new Vector2(0.25f, 1f));
        SpawnBullet(new Vector2(-0.5f, 1f));
        SpawnBullet(new Vector2(0.5f, 1f));
    }
    
    void ShootSpread7()
    {
        for (int i = -3; i <= 3; i++) //It's -3 to 3 because every bullet is being multipled by a single number, if bullet sstart at zero they rotate more each time
        {
            float x = i * 0.25f;
            SpawnBullet(new Vector2(1f, x));
        }
    }

    // void ShootWave() //ERROR: Not working 
    // {
    //     Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
    // }

    IEnumerator BurstRoutine()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnBullet(Vector2.up);
            yield return new WaitForSeconds(0.1f);
        }
    }

    void ShootBurst()
    {
        StartCoroutine(BurstRoutine());
    }

    void ShootHoming()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    void ShootCircle() //L
    {
        int bulletCount = 12;

        for (int i = 0; i < bulletCount; i++)
        {
            float angle = i * (360f / bulletCount);
            float rad = angle * Mathf.Deg2Rad;

            Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
            SpawnBullet(direction);
        }
    }

    // void ShootSpiral() //Fix
    // {
    //     float rad = spiralAngle * Mathf.Deg2Rad;
    //     Vector2 direction = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));

    //     SpawnBullet(direction);

    //     spiralAngle = spiralAngle + 15f;
    // }

    void ShootRain()
    {
        for (int i = 0; i < 10; i++)
        {
            float x = Random.Range(-37f, 37f);
            Vector3 position = new Vector3(x, firePoint.position.y + 15f, 0f);

            GameObject newBullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            ProjectileScript script = newBullet.GetComponent<ProjectileScript>();
            script.direction = Vector2.down;
        }
        for (int i = 0; i < 12; i++)
        {
            float x = Random.Range(-37f, 37f);
            Vector3 position = new Vector3(x, firePoint.position.y + 20f, 0f);

            GameObject newBullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            ProjectileScript script = newBullet.GetComponent<ProjectileScript>();
            script.direction = Vector2.down;
        }
        for (int i = 0; i < 15; i++)
        {
            float x = Random.Range(-37f, 37f);
            Vector3 position = new Vector3(x, firePoint.position.y + 25f, 0f);

            GameObject newBullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            ProjectileScript script = newBullet.GetComponent<ProjectileScript>();
            script.direction = Vector2.down;
        }
        for (int i = 0; i < 9; i++)
        {
            float x = Random.Range(-37f, 37f);
            Vector3 position = new Vector3(x, firePoint.position.y + 30f, 0f);

            GameObject newBullet = Instantiate(bulletPrefab, position, Quaternion.identity);
            ProjectileScript script = newBullet.GetComponent<ProjectileScript>();
            script.direction = Vector2.down;
        }
    }
}
