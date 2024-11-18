using UnityEngine;
using Button = UnityEngine.UI.Button;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createClass;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private LevelsSO _levelSO;

    public void End()
    {
        if (CheckWin()) Win(); else Lose();
        _createClass.DestroyAllCats();
    }
    private void Win()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _victoryPanel.SetActive(true);
        _pointsManager.VictoryEndPoints();

        int currentMaxLevel = PlayerPrefs.GetInt(SaveKeys.MaximumActiveLevel);
        int currentLevel = Level.Current + 1;
        if (currentLevel >= currentMaxLevel)
        {
            PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, currentLevel + 1);
            PlayerPrefs.Save();
        }
    }

    private void Lose()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _defeatPanel.SetActive(true);
        _pointsManager.ResetLevelPoints();
    }

    public bool CheckWin()
    {
        return Points.LevelPoints >= _levelSO.VictoryPoints[Level.Current];
    }
}
