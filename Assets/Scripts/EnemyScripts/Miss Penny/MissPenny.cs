using UnityEngine;

public class MissPenny : MonoBehaviour
{
    public Transform firePoint;   
    public GameObject[] ProjectileTypes;

    public float shootInterval = 1.5f;
    private float shootTimer = 0f;

    void Update()
    {
        shootTimer = shootTimer + Time.deltaTime;

        if (shootTimer >= shootInterval)
        {
            Shoot();
            shootTimer = 0f;
        }
    }

    void Shoot()
    {
        int index = Random.Range(0, ProjectileTypes.Length);

        GameObject chosenBullet = ProjectileTypes[index];

        GameObject newBullet = Instantiate(chosenBullet, firePoint.position, firePoint.rotation);
    }
}