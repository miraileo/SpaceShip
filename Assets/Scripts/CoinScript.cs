using UnityEngine;
using UnityEngine.UI;
using YG;

public class CoinScript : MonoBehaviour
{
    private int coin;
    [SerializeField] private Text coinsText;
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;


    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
        Invoke("LoadMoney", 0.2f);
    }

    public void GetCoin(int numOfCoins)
    {
        coin += numOfCoins;
        MySave();
    }

    public void CoinsText()
    {
        coinsText.text = coin.ToString();
    }

    public void GetLoad()
    {
        coin = YandexGame.savesData.numOfCoins;
    }

    public void MySave()
    {
        YandexGame.savesData.numOfCoins = coin;
        YandexGame.SaveProgress();
    }

    void LoadMoney()
    {
        coinsText.text = YandexGame.savesData.numOfCoins.ToString();
    }

    public bool CheckEnoughMoney(int price)
    {
        bool flag;
        if(coin >= price)
        {
            coin -= price;
            CoinsText();
            flag = true;
            MySave();
        }
        else
        {
            flag = false;
        }
        return flag;
    }

 /*   public void AddMoney()
    {
        coin += 100;
        coinsText.text = coin.ToString();
        MySave();
    }*/
}
