using UnityEngine;

public class CommandorEnemyShipScript : EnemySgipScript
{
    private GameObject origin;
    Spawner spawner;
    CoinScript coin;
    [SerializeField] private Transform shootPos;
    [SerializeField] private Transform shootPos1;
    [SerializeField] private Transform shootPos2;
    [SerializeField] private GameObject bullet;
    private float timeBtwAttack = 0;
    Quaternion angle = Quaternion.Euler(0, 0, -90);
    void Start()
    {
        SetUp();
        health = 1000;
        origin = GameObject.FindGameObjectWithTag("Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            spawner = FindObjectOfType<Spawner>().GetComponent<Spawner>();
            coin = FindObjectOfType<CoinScript>();
            Invoke("GiveMoney", 0.5f);
            spawner.commandorIsAlive = false;
            Die();
        }
        else
        {
            Attack();
        }
    }

    private void FixedUpdate()
    {
        MoveCommandor();
    }
        
    void MoveCommandor()
    {
        transform.position = Vector2.MoveTowards(transform.position, origin.transform.position, 0.05f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            ShipShoot ship = FindObjectOfType<ShipShoot>();
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            health = TakeDamage(ship.damage);
            bullet.DestroyBullet();
        }
        else if (collision.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }

    void GiveMoney()
    {
        coin.AddMoney(30);
    }

    void Attack()
    {
        if (timeBtwAttack <= 0)
        {
            Instantiate(bullet, shootPos.position, angle);
            Instantiate(bullet, shootPos1.position, angle);
            Instantiate(bullet, shootPos2.position, angle);
            timeBtwAttack = 0.7f;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
        }
    }
}
