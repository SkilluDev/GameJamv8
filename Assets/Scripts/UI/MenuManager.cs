#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
  public class MenuManager : MonoBehaviour
  {
    public static MenuManager Instance { get; private set; }

    [SerializeField] private string _menuScene = "Menu";
    [SerializeField] private string _gameScene = "Main Game";
    [SerializeField] private string _cutsceneScene = "Cutscene";

    [SerializeField] private GameObject _background;
    [SerializeField] private GameObject _mainView; 
    [SerializeField] private GameObject _instructionsView;
    [SerializeField] private GameObject _creditsView;

    private bool cutscenePlayed;

    private void Awake()
    {
      cutscenePlayed = PlayerPrefs.GetInt("CutscenePlayed", 0) == 1;

      if (Instance != null && Instance != this)
      {
        Destroy(gameObject);
        return;
      }

      Instance = this;
    }

    private void OnEnable()
    {
      SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
      SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
      bool isMenu = scene.name == _menuScene;

      _background.SetActive(isMenu);

      if (isMenu)
      {
        _mainView.SetActive(true);
        _instructionsView.SetActive(false);
        _creditsView.SetActive(false);
      }
      else
      {
        _mainView.SetActive(false);
        _instructionsView.SetActive(false);
        _creditsView.SetActive(false);
      }
    }

    public void StartClicked()
    {
      if (cutscenePlayed)
      {
        SceneManager.LoadScene(_gameScene);
        return;
      }

      cutscenePlayed = true;
      PlayerPrefs.SetInt("CutscenePlayed", 1);
      SceneManager.LoadScene(_cutsceneScene);
    }

    public void InstructionsClicked()
    {
      _mainView.SetActive(false);
      _instructionsView.SetActive(true);
      _creditsView.SetActive(false);
    }

    public void CreditsClicked()
    {
      _mainView.SetActive(false);
      _instructionsView.SetActive(false);
      _creditsView.SetActive(true);
    }

    public void BackClicked()
    {
      _instructionsView.SetActive(false);
      _mainView.SetActive(true);
      _creditsView.SetActive(false);
    }

    public void ExitClicked()
    {
      #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
      #else
        Application.Quit();
      #endif
    }
  }
}
