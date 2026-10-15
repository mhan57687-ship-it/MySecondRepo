using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI TimeTest;

    public GameObject TimeText;

    public GameObject GameOverPanel;

    public TextMeshProUGUI ScoreText;

    public float time = 60;
    public bool gameOver = false;

    void Update()
    {

        if (gameOver == false)
        {
            time -= Time.deltaTime;
            TimeTest.text = "제한 시간 : " + (int)time;
            if (time <= 0)
            {
                time = 0;
                gameOver = true;
                GameOver();

            }
        }
    }
    public void GameOver()
    {
        GameOverPanel.SetActive(true);
    }
    public void RestartGame()
    {
        TimeText.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void GoToTitle()
    {
        TimeText.SetActive(false);
        SceneManager.LoadScene("Title");
    }

    public int score = 0;

    public void AddScore(int amount)
    {
        score += amount;
        ScoreText.text = "점수 : " + score;
    }
}
