using TMPro;
using UnityEngine;

public class UpdateStartAllCounts : MonoBehaviour
{
    [SerializeField] public TMP_Text ÀllCountsText;

    private void Start()
    {
        Points.AllPoints = PlayerPrefs.GetInt(SaveKeys.AllPoints);
        ÀllCountsText.text = Points.AllPoints.ToString();
    }
}
