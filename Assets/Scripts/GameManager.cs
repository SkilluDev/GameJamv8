using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private SceneChanger sceneChanger;
    public static GameManager Instance { get; private set; }

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
                LoadGameOver();
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

    public void LoadGameOver()
    {
        sceneChanger?.LoadGameOver();
    }
}