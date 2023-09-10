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
            //Time.timeScale = 0;
            counter = 1;
            //Invoke("PriceText", 0.2f);
        }
        else
        {
            store.SetActive(false);
            counter = 0;
            //Time.timeScale = 1;
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
}
