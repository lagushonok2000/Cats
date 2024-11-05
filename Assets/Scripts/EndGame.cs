using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createClass;
    [SerializeField] private Button _nextLevelButton;
    [SerializeField] private Button _restartLevelButton;
    [SerializeField] private Image _defeatPanel;
    [SerializeField] private Image _victoryPanel;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private LevelsSO _levelSO;

    public void End()
    {
        if (CheckWin()) Win(); else Lose();
    }
    private void Win()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _victoryPanel.enabled = true;
        _pointsManager.VictoryEndPoints();
    }

    private void Lose()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _defeatPanel.enabled = true;
        _pointsManager.ResetLevelPoints();
    }
    private bool CheckWin()
    {
        if (Points.LevelPoints >= _levelSO.VictoryPoints[Level.Current]) return true; else return false;
    }
}
