using System.Collections;
using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    [SerializeField] private Transform ShootPos;

    [SerializeField] private GameObject bullet;

    [SerializeField] private GameObject poweredBullet;

    [SerializeField] private GameObject speedBullets;

    [SerializeField] private float timeBtwAttack;

    private float cooldown;

    private float ultiCooldown;

    private bool isPoweredBonus;

    private bool isSpeedBonus;

    Quaternion angle = Quaternion.Euler(0, 0, 90);

    public float damage = 25;

    private void Update()
    {
        cooldown = CheckCooldown(cooldown, timeBtwAttack);
        Shoot();
    }

    private float CheckCooldown(float cooldown, float timeBtwAttack)
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        return cooldown;
    }

    private void Shoot()
    {
        if (cooldown <= 0)
        {
            if (isPoweredBonus == true)
            {
                Instantiate(poweredBullet, ShootPos.position, angle);
            }
            else if(isSpeedBonus == true)
            {
                Instantiate(speedBullets, ShootPos.position, angle);
            }
            else
            {
                Instantiate(bullet, ShootPos.position, angle);
            }
            cooldown = timeBtwAttack;
        }
    }

    public IEnumerator BonusAttackSpeed()
    {
        if (isSpeedBonus != true)
        {
            timeBtwAttack /= 2;
            isSpeedBonus = true;
            yield return new WaitForSeconds(5);
            timeBtwAttack *= 2;
            isSpeedBonus = false;
        }
    }

    public IEnumerator BonusAttackDamage()
    {
        if (isPoweredBonus != true)
        {
            damage *= 2;
            isPoweredBonus = true;
            yield return new WaitForSeconds(5);
            damage /= 2;
            isPoweredBonus = false;
        }
    }

}
