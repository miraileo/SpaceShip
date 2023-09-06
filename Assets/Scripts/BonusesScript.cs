using UnityEngine;

public class BonusesScript : MonoBehaviour
{
    private ShipShoot shipShoot;

    private HealthScript shipHealth;

    private CoinScript coin;

    private bool takeCoin;

    [SerializeField] private ParticleSystem getBonusHit;
    private void Start()
    {
        shipShoot = GetComponent<ShipShoot>();
        shipHealth = GetComponent<HealthScript>();
        coin= GetComponent<CoinScript>();
        GlobalEventManager.dropCoin.AddListener(GiveCoin);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "AttackSpeedBonus")
        {
            StartCoroutine(shipShoot.BonusAttackSpeed());
            PlayParticleSystem(Color.yellow, collision);
        }
        if (collision.tag == "HealthBonus")
        {
            shipHealth.BonusHealthScript();
            getBonusHit.Play();
            PlayParticleSystem(Color.green, collision);
        }
        if (collision.tag == "DamageBonus")
        {
            StartCoroutine(shipShoot.BonusAttackDamage());
            PlayParticleSystem(Color.red, collision);
        }
        if (collision.tag == "Coin")
        {
            takeCoin = true;
            PlayParticleSystem(Color.blue, collision);
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
        if (takeCoin == true)
        {
            coin.GetCoin(numOfCoins);
            takeCoin = false;
        }
    }

}
