using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private int coin;
    [SerializeField] private Text coinsText;

    public void GetCoin(int numOfCoins)
    {
        coin += numOfCoins;
    }

    public void CoinsText()
    {
        coinsText.text = coin.ToString();
    }
}
