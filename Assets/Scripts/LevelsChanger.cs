using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Image = UnityEngine.UI.Image;

public class LevelsChanger : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Panel _defeatPanel;
    [SerializeField] private Image _victoryPanel;
    [SerializeField] private LevelsSO _levelsSO;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createCats;
    [SerializeField] private PointsManager _pointsManager;

    public int _currentLevel = 0;

    private void Start()
    {
        _startButton.onClick.AddListener(() => SetLevel(_currentLevel));
        _nextLevelButton.onClick.AddListener(NextLevel);
        _currentLevel = (Level.Current);
    }

    public void SetLevel(int level)
    {
        _currentLevel = level;
        _pointsManager.ResetLevelPoints();
        _startButton.gameObject.SetActive(false);
        _levelTimer.StartTimer(_levelsSO.TimeOnLevel[level]);
        StartCoroutine(_createCats.ObjectsCreation());
    }

    public void RestartLevel()
    {
        _defeatPanel.enabled = false;
    }

    public void NextLevel()
    {
        _currentLevel++;
        _victoryPanel.enabled = false;
        _startButton.gameObject.SetActive(true);
    }
}