using UnityEngine;

public class CoinMovemingScript : MonoBehaviour
{
    private GameObject player; 
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 0.2f);
    }
}
