using UnityEngine;
using UnityEngine.UI;

public class LevelsChanger : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _nextButton;
    [SerializeField] private LevelsSO _levelsSO;
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createCats;

    public int _currentLevel = 0;

    private void Start()
    {
        _startButton.onClick.AddListener(() => SetLevel(_currentLevel));
        _nextButton.onClick.AddListener(NextLevel);
        _currentLevel = (Level.Current);
    }

    public void SetLevel(int level)
    {
        _currentLevel = level;
        _startButton.gameObject.SetActive(false);
        _levelTimer.StartTimer(_levelsSO.TimeOnLevel[level]);
        StartCoroutine(_createCats.ObjectsCreation());
    }

    public void NextLevel()
    {
        _currentLevel++;
        _nextButton.gameObject.SetActive(false);
        _startButton.gameObject.SetActive(true);
    }
}