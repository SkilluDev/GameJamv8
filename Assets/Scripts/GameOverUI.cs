using UnityEngine;
using TMPro;   
using GameOverReason = GameManager.GameOverReason;
public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TMP_Text messageText;
 

    private void Start()
    {
        if (messageText == null)
        {
            Debug.LogError("GameOverUI: messageText not assigned!");
            return;
        }

        var gm = GameManager.Instance;
        if (gm == null)
        {
            messageText.text = "Game Over";
            return;
        }

        switch (gm.LastGameOverReason)
        {
            case GameOverReason.TimeUp:
                messageText.text = "Time's up!";
                break;
            case GameOverReason.PlayerDead:
                messageText.text = "You died! Skill issue...";
                break;
            default:
                messageText.text = "Game Over";
                break;
        }
    }
}