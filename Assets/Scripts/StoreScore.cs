using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using YG;
using YG.Example;

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

    private void OnEnable()
    {
        YandexGame.RewardVideoEvent += Rewarded;
        YandexGame.GetDataEvent += GetLoad;
    }

    private void OnDisable()
    {
        YandexGame.RewardVideoEvent -= Rewarded;
        YandexGame.GetDataEvent -= GetLoad;
    }

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
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            PriceText();
        }
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
        store.SetActive(true);
    }
    public void CloseStore()
    {
        store.SetActive(false);
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

    private void Rewarded(int id)
    {
        if (id == 1)
        {
            coinScript.AddMoney();
        }
    }

    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
