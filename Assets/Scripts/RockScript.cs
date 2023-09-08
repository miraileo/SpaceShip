using UnityEngine;

public class RockScript : MonoBehaviour
{

    public float damage = 40;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "DeathZone")
        {
            Destroy(gameObject);
        }
    }
}
