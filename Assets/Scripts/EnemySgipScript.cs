using UnityEngine;

public class EnemySgipScript : MonoBehaviour
{
    private Rigidbody2D rigidbody2;
    [SerializeField] float speed;
    public float health = 100;
    [SerializeField] private GameObject hitEffect;
    void Start()
    {
        rigidbody2 = GetComponent<Rigidbody2D>();
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
        Destroy(gameObject);
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
}
