using UnityEngine;

public class BulletScript : MonoBehaviour
{
    [SerializeField] private float bulletSpeed;
    private Rigidbody2D rigidbody2;

    [SerializeField] private GameObject hitEffect;


    private void Start()
    {
        rigidbody2= GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        MoveBullet();
    }
    private void MoveBullet()
    {
        rigidbody2.velocity = new Vector2(0, bulletSpeed);
        Invoke("Destroy", 1.6f);
    }

    #region bulletCollision
    private void DisableBullet(GameObject bullet)
    {
        bullet.GetComponent<Renderer>().enabled = false;
        bulletSpeed = 0;
    }

    private void HitEffect()
    {
        hitEffect.SetActive(true);
        Invoke("DisableHitEffect", 0.35f);
    }

    public void DestroyBullet()
    {
        HitEffect();
        DisableBullet(gameObject);
        Invoke("Destroy", 0.35f);
    }

    private void Destroy() { Destroy(gameObject); }
    private void DisableHitEffect() { hitEffect.SetActive(false); }
    #endregion
}
