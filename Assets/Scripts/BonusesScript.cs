using UnityEngine;
using static Unity.VisualScripting.Member;

public class BonusesScript : MonoBehaviour
{
    private ShipShoot shipShoot;

    private HealthScript shipHealth;

    private CoinScript coin;

    AudioScript source;

    [SerializeField] private ParticleSystem getBonusHit;
    private void Start()
    {
        shipShoot = GetComponent<ShipShoot>();
        shipHealth = GetComponent<HealthScript>();
        coin= GetComponent<CoinScript>();
        GlobalEventManager.dropCoin.AddListener(GiveCoin);
        source = FindObjectOfType<AudioScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AttackSpeedBonus")
        {
            StartCoroutine(shipShoot.BonusAttackSpeed());
            PlayParticleSystem(Color.yellow, collision);
            source.PickUp();
        }
        if (collision.tag == "HealthBonus")
        {
            shipHealth.BonusHealthScript();
            getBonusHit.Play();
            PlayParticleSystem(Color.green, collision);
            source.PickUp();
        }
        if (collision.tag == "DamageBonus")
        {
            StartCoroutine(shipShoot.BonusAttackDamage());
            PlayParticleSystem(Color.red, collision);
            source.PickUp();
        }
        if (collision.tag == "Coin")
        {
            coin.CoinsText();
            PlayParticleSystem(Color.cyan, collision);
            source.PickUp();
        }
        if (collision.tag == "Rock")
        {
            RockScript rock = collision.GetComponent<RockScript>();
            shipHealth.TakeDamage(rock.damage);
            PlayParticleSystem(Color.gray, collision);
            source.Destroy();
        }
    }

    void PlayParticleSystem(Color color, Collider2D collision)
    {
        Destroy(collision.gameObject);
        var main = getBonusHit.main;
        main.startColor = color;
        getBonusHit.Play();
    }

    private void GiveCoin(int numOfCoins)
    {
        coin.GetCoin(numOfCoins);
    }

}
