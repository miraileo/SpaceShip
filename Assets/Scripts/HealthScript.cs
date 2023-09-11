using UnityEngine;
using UnityEngine.UI;
using YG;

public class HealthScript : MonoBehaviour
{
    private float health = 100;

    [SerializeField] private GameObject hitEffect;

    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject deathPanel;

    CoinScript coins;

    private void Awake()
    {
        coins= GetComponent<CoinScript>();
    }

    void Update()
    {
        if(health<=0)
        {
            setActive(gameObject);
            HitEffect();
            Invoke("Destroy", 0.5f);
            coins.MySave();
        }
        HealthBarUpdate();

        if( health >=100)
        {
            health = 100;
        }
    }

    private void setActive(GameObject hui)
    {
        hui.GetComponent<Renderer>().enabled = false;
    }

    private void Destroy()
    {
        deathPanel.SetActive(true);
        Time.timeScale = 0;
        GlobalEventManager.SendBestScore();
        Destroy(gameObject);
    }

    private void HitEffect()
    {
        hitEffect.SetActive(true);
    }

    private void HealthBarUpdate()
    {
        healthBar.fillAmount = health / 100;
    }

    public void BonusHealthScript()
    {
        if (health < 100)
        {
            health += 20;
            if (health >= 100)
            {
                health = 100;
            }
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "EnemyBullet")
        {
            BulletScript bullet = collision.gameObject.GetComponent<BulletScript>();
            TakeDamage(10);
            bullet.DestroyBullet();
        }
    }
}
