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
    }

    private void Lose()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _defeatPanel.SetActive(true);
        _pointsManager.ResetLevelPoints();
    }

    private bool CheckWin()
    {
        return Points.LevelPoints >= _levelSO.VictoryPoints[Level.Current];
    }
}
