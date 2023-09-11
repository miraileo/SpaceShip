using UnityEngine;
using UnityEngine.UI;
using YG;

public class StoreScore : MonoBehaviour
{
    CoinScript coinScript;
    private float damageBonuce = 10;
    private float attackSpeedBonuce = 0.05f;
    private int priceForDamage;
    private int priceForAttackSpeed;
    [SerializeField] private Text priceForDamageText;
    [SerializeField] private Text priceForAttckSpeedText;
    [SerializeField] private GameObject store;
    int counter = 0;

/*    private void OnEnable() => YandexGame.RewardVideoEvent += Rewarded;

    private void OnDisable() => YandexGame.RewardVideoEvent -= Rewarded;*/

    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void Start()
    {
        coinScript = (CoinScript)FindObjectOfType(typeof(CoinScript));
    }

    private void Update()
    {
        PriceText();
    }

    public void DamageUpgrade()
    {
        if (coinScript.CheckEnoughMoney(priceForDamage))
        {
            GlobalEventManager.DamageUpgrade(damageBonuce);
            priceForDamage *= 2;
            MySave();
        }
    }

    public void AttackSpeedUpgrade()
    {
        if (coinScript.CheckEnoughMoney(priceForAttackSpeed))
        {
            GlobalEventManager.AttackSpeedUpgrade(attackSpeedBonuce);
            priceForAttackSpeed *= 2;
            MySave();
        }
    }

    public void OpenStore()
    {
        if (counter == 0)
        {
            store.SetActive(true);
            counter = 1;
        }
        else
        {
            counter = 0;
            store.SetActive(false);
        }
    }

    public void GetLoad()
    {
        priceForDamage = YandexGame.savesData.priceForDamageUpgrade;
        priceForAttackSpeed = YandexGame.savesData.priceForAttackSpeedUpgrade;
    }

    public void MySave()
    {
        YandexGame.savesData.priceForDamageUpgrade = priceForDamage;
        YandexGame.savesData.priceForAttackSpeedUpgrade = priceForAttackSpeed;
        YandexGame.SaveProgress();
    }

    void PriceText()
    {
        priceForDamageText.text = YandexGame.savesData.priceForDamageUpgrade.ToString();
        priceForAttckSpeedText.text = YandexGame.savesData.priceForAttackSpeedUpgrade.ToString();
    }

/*    private void Rewarded(int id)
    {
        if (id == 1)
        {
            coinScript.AddMoney();
        }
    }

    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }*/
}
