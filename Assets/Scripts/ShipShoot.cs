using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    [SerializeField] private Transform ShootPos;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float timeBtwAttack;

    [SerializeField] private float timeBtwUltiAttack;

    private float cooldown;

    private float ultiCooldown;

    Quaternion angle = Quaternion.Euler(0, 0, 90);

    private void Update()
    {
        cooldown = CheckCooldown(cooldown, timeBtwAttack);
        ultiCooldown = CheckCooldown(ultiCooldown, timeBtwUltiAttack);
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
            Instantiate(bullet, ShootPos.position, angle);
            cooldown = timeBtwAttack;
        }
    }

    public void UltimateShoot(GameObject bullet)
    {
        if (ultiCooldown <= 0)
        {
            Instantiate(bullet, ShootPos.position, angle);
            ultiCooldown = timeBtwUltiAttack;
        }
    }
    
}
