using UnityEngine;
using UnityEngine.SceneManagement;
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
    private int attackSpeedUpgrades;
    [SerializeField] private Text attackSpeedUpgradesText;
    [SerializeField] private Button attackSpeedUpgradeButton;

    public Button storeButton;

    AudioScript source;
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
        source = FindObjectOfType<AudioScript>();
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
        if (coinScript.CheckEnoughMoney(priceForAttackSpeed) && attackSpeedUpgrades<5)
        {
            GlobalEventManager.AttackSpeedUpgrade(attackSpeedBonuce);
            priceForAttackSpeed *= 2;
            attackSpeedUpgrades++;
            MySave();
        }
        else if(attackSpeedUpgrades == 5)
        {
            attackSpeedUpgradeButton.interactable = false;
        }
    }

    public void OpenStore()
    {
        store.SetActive(true);
        source.sourceButton.interactable = false;
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            coinScript.LoadMoney();
        }
    }
    public void CloseStore()
    {
        source.sourceButton.interactable = true;
        store.SetActive(false);
    }

    public void GetLoad()
    {
        priceForDamage = YandexGame.savesData.priceForDamageUpgrade;
        priceForAttackSpeed = YandexGame.savesData.priceForAttackSpeedUpgrade;
        attackSpeedUpgrades = YandexGame.savesData.attackSpeedUpgrades;
    }

    public void MySave()
    {
        YandexGame.savesData.priceForDamageUpgrade = priceForDamage;
        YandexGame.savesData.priceForAttackSpeedUpgrade = priceForAttackSpeed;
        YandexGame.savesData.attackSpeedUpgrades = attackSpeedUpgrades;
        YandexGame.SaveProgress();
    }

    void PriceText()
    {
        priceForDamageText.text = YandexGame.savesData.priceForDamageUpgrade.ToString();
        priceForAttckSpeedText.text = YandexGame.savesData.priceForAttackSpeedUpgrade.ToString();
        attackSpeedUpgradesText.text = YandexGame.savesData.attackSpeedUpgrades.ToString() + "/5";
    }

    private void Rewarded(int id)
    {
        if (id == 1)
        {
            coinScript.AddMoney(100);
        }
    }

    public void ExampleOpenRewardAd(int id)
    {
        YandexGame.RewVideoShow(id);
    }
}
