using UnityEngine;

public class EnemySgipScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    [SerializeField] float speed;
    public float health = 100;
    [SerializeField] private GameObject hitEffect;
    [SerializeField] private int score;
    BonusesDropScript bonus;
    public float damage;

    protected LeaderBoard leaderBoard;

    void Start()
    {
        GetScore(); 
        SetUp();
    }

    void FixedUpdate()
    {
        Move();
        if(health<=0)
        {
            Die();
        }
    }

    void Move()
    {
        rigidbody2.velocity = new Vector2(0, -speed);
    }

    public float TakeDamage(float damage)
    {
        health -= damage;
        return health;
    }

    private void setActive(GameObject hui)
    {
        hui.GetComponent<Renderer>().enabled = false;
    }

    private void Destroy()
    {
        GlobalEventManager.SendScore(score);
        bonus.RandomDrop();
        DestroyImmediate(gameObject);
    }

    private void HitEffect()
    {
        hitEffect.SetActive(true);
    }

    public void Die()
    {
        HitEffect();
        speed = 0;
        setActive(gameObject);
        Invoke("Destroy", 0.5f);
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
        else if(collision.tag == "Player")
        {
            HealthScript player = collision.gameObject.GetComponent<HealthScript>();
            player.TakeDamage(damage);
            Die();
        }
    }

    protected void SetUp()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
        bonus = GetComponent<BonusesDropScript>();
    }

    void GetScore()
    {
        leaderBoard = FindObjectOfType<LeaderBoard>().GetComponent<LeaderBoard>();
        if(leaderBoard._score%10 >= 0)
        {
            health += leaderBoard._score*2;
            speed += 0.35f*leaderBoard._score/10;
        }
    }
}
