using UnityEngine;
using UnityEngine.UI;
using YG;

public class LeaderBoard : MonoBehaviour
{
    private int finalScore = 0;
    public int _score = 0;

    [SerializeField] private Text recordText;
    [SerializeField] private Text scoreText;
    [SerializeField] private Text scoreTextInGame;

    private void Awake()
    {
        if (YandexGame.SDKEnabled == true)
        {
            GetLoad();
        }
    }

    private void Start()
    {
        GlobalEventManager.onEnemyKilled.AddListener(GiveScore);
        GlobalEventManager.setBestScore.AddListener(GiveBestScore);
    }
    private void OnEnable() => YandexGame.GetDataEvent += GetLoad;
    private void OnDisable() => YandexGame.GetDataEvent -= GetLoad;

    private void GiveScore(int score)
    {
        _score += score;
        scoreText.text = "Счет: " + _score.ToString();
        scoreTextInGame.text = _score.ToString();
    }

    private void GiveBestScore()
    {
        if (YandexGame.savesData.record <= _score)
        {
            finalScore = _score;
            recordText.text = "Рекорд: " + finalScore.ToString();
            YandexGame.NewLeaderboardScores("LeaderBoard", finalScore);
            MySave();
        }
        else
        {
            recordText.text = "Рекорд: " + finalScore.ToString();
        }
    }

    public void GetLoad()
    {
        finalScore = YandexGame.savesData.record;
    }

    public void MySave()
    {
        YandexGame.savesData.record = finalScore;
        YandexGame.SaveProgress();
    }
}
