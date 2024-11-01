using TMPro;
using UnityEngine;

public class UpdateStartAllCounts : MonoBehaviour
{
    [SerializeField] private TMP_Text _allCountsText;

    private void Start()
    {
        Counts.AllCounts = PlayerPrefs.GetInt(SaveKeys.AllCounts);
        _allCountsText.text = Counts.AllCounts.ToString();
    }

    
}
