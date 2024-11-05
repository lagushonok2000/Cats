using TMPro;
using UnityEngine;

public class UpdateStartAllCounts : MonoBehaviour
{
    [SerializeField] private TMP_Text _allCountsText;

    private void Start()
    {
        Points.AllPoints = PlayerPrefs.GetInt(SaveKeys.AllPoints);
        _allCountsText.text = Points.AllPoints.ToString();
    }
}
