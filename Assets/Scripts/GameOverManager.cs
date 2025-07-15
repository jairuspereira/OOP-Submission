using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public GameObject gameOverScreen;

    private bool isGameOver = false;

    public void Start()
    {
        gameOverScreen.SetActive(false);
    }
    public void TriggerGameOver()
    {
        if (isGameOver) return;

        isGameOver = true;
        Time.timeScale = 0f; // freeze game
        gameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOverScreen.SetActive(false);
    }
}