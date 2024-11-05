using TMPro;
using UnityEngine;

public class PointsManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _levelPointsText;
 
    private void Start()
    {
        _levelPointsText.text = "0";
    }
    public void PointsAdd(int add)
    {
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
        _levelPointsText.text = Points.LevelPoints.ToString();
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
