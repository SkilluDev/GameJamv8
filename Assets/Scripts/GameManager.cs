using UnityEngine;
using System; 

public class GameManager : MonoBehaviour
{
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
  }

  [Header("Timer")]
  [SerializeField] private float timeRemaining = 60f;

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
        Debug.Log("Time has run out");
        
        OnTimerEnd?.Invoke();
        
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
}