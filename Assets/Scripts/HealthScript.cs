using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    private float health = 100;

    [SerializeField] private GameObject hitEffect;

    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject deathPanel;

    void Update()
    {
        if(health<=0)
        {
            setActive(gameObject);
            HitEffect();
            Invoke("Destroy", 0.5f);
        }
        HealthBarUpdate();

        if( health >=100)
        {
            health = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health -= 20;
            EnemySgipScript enemy = collision.gameObject.GetComponent<EnemySgipScript>();
            enemy.health = 0;
            enemy.Die();
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
}
