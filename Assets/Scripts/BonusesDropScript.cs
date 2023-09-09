using UnityEngine;
using UnityEngine.Events;

public class BonusesDropScript : MonoBehaviour
{

    [SerializeField] private GameObject attackSpeedBonus;
    [SerializeField] private GameObject attackDamageBonus;
    [SerializeField] private GameObject healthBonus;
    [SerializeField] private GameObject coin;

    [SerializeField] private int numOfCoins = 5;

    void DropAttackSpeedBonus()
    {
        Instantiate(attackSpeedBonus, transform.position, Quaternion.identity);
    }
    void DropDamageBonus()
    {
        Instantiate(attackDamageBonus, transform.position, Quaternion.identity);
    }
    void DropHealthBonus()
    {
        Instantiate(healthBonus, transform.position, Quaternion.identity);
    }

    void DropCoin()
    {
        Instantiate(coin, transform.position, Quaternion.identity);
        GlobalEventManager.DropCoin(numOfCoins);
    }

    public void RandomDrop()
    {
        int random = Random.Range(0, 8);
        switch(random)
        {
            case 0:
            DropAttackSpeedBonus();
            break;
            case 1:
            DropDamageBonus();
            break;
            case 2:
            DropHealthBonus();
            break;
            default:
            DropCoin();
            break;
        }
    }
}
