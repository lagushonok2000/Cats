using UnityEngine;
using Button = UnityEngine.UI.Button;

public class LevelsChanger : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private LevelsSO _levelsSO;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createCats;
    [SerializeField] private PointsManager _pointsManager;

    private void Start()
    {
        _startButton.onClick.AddListener(() => SetLevel(Level.Current));
        _nextLevelButton.onClick.AddListener(NextLevel);
        _restartLevelButton.onClick.AddListener(RestartLevel);
    }

    public void SetLevel(int level)
    {
        Level.Current = level;
        _pointsManager.ResetLevelPoints();
        _startButton.gameObject.SetActive(false);
        _levelTimer.StartTimer(_levelsSO.TimeOnLevel[level]);
        StartCoroutine(_createCats.ObjectsCreation());
    }

    public void RestartLevel()
    {
        _defeatPanel.SetActive(false);
        _startButton.gameObject.SetActive(true);
    }

    public void NextLevel()
    {
        Level.Current++;
        _victoryPanel.SetActive(false);
        _startButton.gameObject.SetActive(true);
    }
}