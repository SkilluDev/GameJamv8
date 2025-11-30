using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public enum GameOverReason
    {
        None,
        TimeUp,
        PlayerDead
    }

    public GameOverReason LastGameOverReason { get; private set; } = GameOverReason.None;
    private SceneChanger sceneChanger;

    public PlayerHealth playerHealth;
    public static GameManager Instance { get; private set; }

    public Transform cameraHolder;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }

        if (sceneChanger == null)
        {
            sceneChanger = GetComponent<SceneChanger>();
            if (sceneChanger == null) Debug.LogError("SceneChanger is null");
        }
    }

    [Header("Timer")] [SerializeField] private float timeRemaining = 60f;

    public float TimeRemaining => timeRemaining;
    public static event Action OnTimerEnd;

    private bool timerIsRunning = true;

    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                OnTimerEnd?.Invoke();
                GameOverByTime();
                enabled = false;
            }
        }
    }

    public void AddMoreTime(float timeToAdd)
    {
        if (timeToAdd > 0)
        {
            timeRemaining += timeToAdd;
            Debug.Log($"Added {timeToAdd} seconds");

            if (!timerIsRunning && timeRemaining > 0)
            {
                StartTimer();
            }
        }
    }

    public void StartTimer()
    {
        timerIsRunning = true;
    }

    public void LoadMenu()
    {
        sceneChanger?.LoadMenu();
    }

    public void LoadGame()
    {
        sceneChanger?.LoadGame();
    }

    public void LoadFinish()
    {
        sceneChanger?.LoadFinish();
    }
    public void GameOverByTime()
    {
        LastGameOverReason = GameOverReason.TimeUp;
        sceneChanger?.LoadGameOver();
    }

    public void GameOverByDeath()
    {
        LastGameOverReason = GameOverReason.PlayerDead;
        sceneChanger?.LoadGameOver();
    }

    public static void Nullify()
    {
        Instance = null;
    }

}