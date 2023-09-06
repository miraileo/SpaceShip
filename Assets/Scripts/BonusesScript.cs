using UnityEngine;

public class BonusesScript : MonoBehaviour
{
    private ShipShoot shipShoot;

    private HealthScript shipHealth;

    [SerializeField] private ParticleSystem getBonusHit;
    private void Start()
    {
        shipShoot = GetComponent<ShipShoot>();
        shipHealth = GetComponent<HealthScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AttackSpeedBonus")
        {
            StartCoroutine(shipShoot.BonusAttackSpeed());
            PlayParticleSystem(Color.yellow);
        }
        if (collision.tag == "HealthBonus")
        {
            shipHealth.BonusHealthScript();
            getBonusHit.Play();
            PlayParticleSystem(Color.green);
        }
        if (collision.tag == "DamageBonus")
        {
            StartCoroutine(shipShoot.BonusAttackDamage());
            PlayParticleSystem(Color.red);
        }
    }

    void PlayParticleSystem(Color color)
    {
        var main = getBonusHit.main;
        main.startColor = color;
        getBonusHit.Play();
    }

}
