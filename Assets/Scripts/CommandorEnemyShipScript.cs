using UnityEngine;

public class CommandorEnemyShipScript : EnemySgipScript
{
    private GameObject origin;
    void Start()
    {
        SetUp();
        health = 1000;
        origin = GameObject.FindGameObjectWithTag("Origin");
    }

    // Update is called once per frame
    void Update()
    {
        if(health<=0)
        {
            Die();
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

   
}
