using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChanger : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string menuSceneName = "Menu";
    [SerializeField] private string gameSceneName = "Main Game";
    [SerializeField] private string finishSceneName = "Finish";
    [SerializeField] private string gameOverSceneName = "GameOver";

    public void LoadMenu()
    {
        SceneManager.LoadScene(menuSceneName);
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(gameSceneName);
    }

    public void LoadFinish()
    {
        SceneManager.LoadScene(finishSceneName);
        StartCoroutine(BackToMenuAfterDelay(5f));
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene(gameOverSceneName);
        StartCoroutine(BackToMenuAfterDelay(5f));
    }
    private IEnumerator BackToMenuAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        LoadMenu();
    }
}