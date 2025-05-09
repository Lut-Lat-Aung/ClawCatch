using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Point : " + score.ToString();
    }
}
