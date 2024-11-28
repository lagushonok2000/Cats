using TMPro;
using UnityEngine;

public class UpdateStartAllCounts : MonoBehaviour
{
    [SerializeField] public TMP_Text �llCountsText;

    private void Start()
    {
        Points.AllPoints = PlayerPrefs.GetInt(SaveKeys.AllPoints);
        �llCountsText.text = Points.AllPoints.ToString();
    }
}
