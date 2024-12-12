using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private EndGame _endGame;
    [SerializeField] public TMP_Text _levelPointsText;
    [SerializeField] public TMP_Text _goalpoints;

    private void Start()
    {
        _levelPointsText.text = "0";
    }
    public void PointsAdd(int add)
    {
        if ((Points.LevelPoints + add)< 0)
        {
            Points.LevelPoints = 0;
            _levelPointsText.text = "0";
            return;
        }
        
        Points.LevelPoints += add;
        _levelPointsText.text = Points.LevelPoints.ToString();
    }
    public void ResetLevelPoints()
    {
        Points.LevelPoints = 0;
        _levelPointsText.text = Points.LevelPoints.ToString();
    }

    public void VictoryEndPoints()
    {
        AddPointsToAll();
        SavePoints();
        _levelPointsText.text = "";
        _endGame._pointsVictoryPanelText.text = Points.LevelPoints.ToString();
    }

    private void AddPointsToAll()
    {
        Points.AllPoints += Points.LevelPoints;
    }

    private void SavePoints()
    {
        PlayerPrefs.SetInt(SaveKeys.AllPoints, Points.AllPoints);
        PlayerPrefs.Save();
    }
}
