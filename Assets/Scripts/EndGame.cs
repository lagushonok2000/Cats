using TMPro;
using UnityEngine;
using Button = UnityEngine.UI.Button;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createClass;
    [SerializeField] private LevelsChanger _levelsChanger;
    [SerializeField] private GameObject _defeatPanel;
    [SerializeField] private GameObject _victoryPanel;
    [SerializeField] private PointsManager _pointsManager;
    [SerializeField] private LevelsSO _levelSO;
    [SerializeField] private Animator _hammerCatAnimator;
    [SerializeField] private AudioSource _audioVictory;
    [SerializeField] public TMP_Text _pointsVictoryPanelText;

    public void End()
    {
        if (CheckWin()) Win(); else Lose();
        _createClass.DestroyAllCats();
        _hammerCatAnimator.SetBool("HammerMove", false);
        _pointsManager._goalpoints.text = "";
        _levelsChanger._GoalPointsText.gameObject.SetActive(false);
        _levelsChanger._currentLevelName.gameObject.SetActive(false);
        _levelsChanger._currentLevelText.text = "";
    }
    private void Win()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _victoryPanel.SetActive(true);
        _pointsManager.VictoryEndPoints();
        _audioVictory.Play();

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
