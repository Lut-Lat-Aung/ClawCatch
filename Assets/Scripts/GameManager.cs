
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;

    public GameObject NextLevelPanel;

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddPoint()
    {
        score++;
        UpdateScoreUI();
        if (score == 16)
        {
            NextLevelPanel.SetActive(true);
            //scoreText.gameObject.SetActive(false);

        }
    }

    void UpdateScoreUI()
    {
        scoreText.text = "Point : " + score.ToString();
    }
}
