using UnityEngine;

public class BonusesDropScript : MonoBehaviour
{
    private ShipShoot shipShoot;

    private HealthScript shipHealth;
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
        }
        if (collision.tag == "HealthBonus")
        {
            shipHealth.BonusHealthScript();
        }
        if (collision.tag == "DamageBonus")
        {
            StartCoroutine(shipShoot.BonusAttackDamage());
        }
    }

}
