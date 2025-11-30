using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class CutsceneManager : MonoBehaviour
{
  public VideoPlayer videoPlayer;

  void Start()
  {
    SceneManager.LoadScene("Main Game");
    videoPlayer.loopPointReached += EndReached;
  }

  void EndReached(VideoPlayer vp)
  {
    vp.Stop();
    vp.gameObject.SetActive(false);
    SceneManager.LoadScene("Main Game");
  }
}
