using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GM : MonoBehaviour
{
    public static GM Instance { get; private set; }

    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text GameoverText;

    private int score = 0;

    private void Update()
    {
        UpdateScoreUI();
    }

    public void AddScore(int value)
    {
        score += value;
        score = Mathf.Max(score, 0);
        UpdateScoreUI();
    }

    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {

            scoreText.text = "Score:" + score.ToString();
            GameoverText.text = "Score: " + score.ToString();
        }
    }

    private void Awake()
    {
        Instance = this;
    }
}