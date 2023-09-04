using UnityEngine;
using UnityEngine.UI;
using YG;

public class HealthScript : MonoBehaviour
{
    private float health = 100;

    [SerializeField] private GameObject hitEffect;

    [SerializeField] private Image healthBar;

    [SerializeField] private GameObject deathPanel;

    int score;

    void Update()
    {
        if(health<=0)
        {
            YandexGame.NewLeaderboardScores("LeaderBoard", score);
            setActive(gameObject);
            HitEffect();
            Invoke("Destroy", 0.5f);
        }
        HealthBarUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy")
        {
            health -= 20;
            EnemySgipScript enemy = collision.gameObject.GetComponent<EnemySgipScript>();
            enemy.health = 0;
            enemy.Die();
            score++;
        }
    }

    private void setActive(GameObject hui)
    {
        hui.GetComponent<Renderer>().enabled = false;
    }

    private void Destroy()
    {
        Destroy(gameObject);
        deathPanel.SetActive(true);
        Time.timeScale = 0;
    }

    private void HitEffect()
    {
        hitEffect.SetActive(true);
    }

    private void HealthBarUpdate()
    {
        healthBar.fillAmount = health / 100;
    }
}
