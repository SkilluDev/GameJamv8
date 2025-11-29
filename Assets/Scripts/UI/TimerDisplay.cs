using UnityEngine;
using TMPro;
public class TimerDisplay : MonoBehaviour
{
  [SerializeField] private TextMeshProUGUI timerText;

  void Update()
  {
    if (GameManager.Instance == null)
    {
      return;
    }

    float time = GameManager.Instance.TimeRemaining;
    
    int minutes = Mathf.FloorToInt(time / 60f);
    int seconds = Mathf.FloorToInt(time % 60f);

    string formattedTime = string.Format("{0:00}:{1:00}", minutes, seconds);

    if (timerText != null)
      {
        timerText.text = formattedTime;
      }
  }
}