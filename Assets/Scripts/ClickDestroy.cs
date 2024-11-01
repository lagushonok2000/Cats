using TMPro;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
    [SerializeField] private TMP_Text _countsText;

    private void Start()
    {
        _countsText.text = Counts.AllCounts.ToString();
    }
    public void ClickOnCat(int add)
    {
        Counts.AllCounts += add;
        _countsText.text = Counts.AllCounts.ToString();
    }
}
