using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void QuitGame()
    {
        EditorApplication.ExitPlaymode();
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }
}
