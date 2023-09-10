using UnityEngine.Events;

public class GlobalEventManager
{
    public static UnityEvent<int> onEnemyKilled = new UnityEvent<int>();

    public static UnityEvent setBestScore = new UnityEvent();

    public static UnityEvent<int> dropCoin = new UnityEvent<int>();
    public static UnityEvent<float> damageUpgrade = new UnityEvent<float>();
    public static UnityEvent<float> attackSpeedUpgrade = new UnityEvent<float>();

    public static void SendScore(int score)
    {
        onEnemyKilled.Invoke(score);
    }

    public static void SendBestScore()
    {
        setBestScore.Invoke();
    }

    public static void DropCoin(int numOfCoins)
    {
        dropCoin.Invoke(numOfCoins);
    }

    public static void DamageUpgrade(float bonuce)
    {
        damageUpgrade.Invoke(bonuce);
    }

    public static void AttackSpeedUpgrade(float bonuce)
    {
        attackSpeedUpgrade.Invoke(bonuce);
    }
}
