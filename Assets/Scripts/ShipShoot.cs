using UnityEngine;

public class ShipShoot : MonoBehaviour
{
    [SerializeField] private Transform ShootPos;

    [SerializeField] private GameObject bullet;

    [SerializeField] private float timeBtwAttack;

    private float cooldown;

    Quaternion angle = Quaternion.Euler(0, 0, 90);

    public void Shoot(GameObject bullet)
    {
        Instantiate(bullet, ShootPos.position, angle);
    }

    private void Update()
    {
        if (cooldown > 0)
        {
            cooldown -= Time.deltaTime;
        }
        else
        {
            Shoot(bullet);
            cooldown = timeBtwAttack;
        }
    }
}
