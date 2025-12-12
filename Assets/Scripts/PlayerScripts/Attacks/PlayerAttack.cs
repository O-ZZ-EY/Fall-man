using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public Collider2D AttackHitbox;
    public GameManager gameManager;

    [Header("Weapon")]
    public float damage = 100;


    [Header("Attacking variables")]
    public bool attackRequest = false;
    public float attackTimer = 0f;
    public float attackTimerCurrent;
    public float attackCooldown = .1f;


    void Start()
    {
        AttackHitbox = transform.GetChild(1).GetComponent<Collider2D>();
        attackTimerCurrent = attackTimer;
        AttackHitbox.enabled = false;
        attackTimer = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !attackRequest)
        {
            attackRequest = true;
        }
    }

    void FixedUpdate()
    {
        if(attackRequest && attackTimer < attackCooldown)
        {
            attackTimer += Time.fixedDeltaTime;
            AttackHitbox.enabled = true;
        }
        else
        {
            AttackHitbox.enabled = false;
            attackTimer = 0f;
            attackRequest = false;
        }
    }



}
