using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D rigidbody2;
    public float damage = 15;

    [SerializeField] private GameObject hitEffect;


    private void Start()
    {
        rigidbody2= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        rigidbody2.velocity = new Vector2(0, bulletSpeed);
        Invoke("DestryBullet", 1.5f);
    }
    private void DestryBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            EnemySgipScript enemy = collision.GetComponent<EnemySgipScript>();
            enemy.health = enemy.TakeDamage(damage);
            bulletSpeed = 0;
            setActive(gameObject);
            HitEffect();
        }
    }

    private void setActive(GameObject hui)
    {
        hui.GetComponent<Renderer>().enabled = false;
    }

    private void HitEffect()
    {
        hitEffect.SetActive(true);
        Invoke("DisableHitEffect", 0.35f);
    }
    private void DisableHitEffect()
    {
        hitEffect.SetActive(false);
    }
}
