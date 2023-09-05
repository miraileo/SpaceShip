using UnityEngine;

public class BonusesDropScript : MonoBehaviour
{

    [SerializeField] private GameObject attackSpeedBonus;
    [SerializeField] private GameObject attackDamageBonus;
    [SerializeField] private GameObject healthBonus;

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

    public void RandomDrop()
    {
        int random = Random.Range(0, 3);
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
        }
    }
}
