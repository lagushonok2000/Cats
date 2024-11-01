using UnityEngine;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    [SerializeField] private LevelTimer _levelTimer;
    [SerializeField] private CreateCats _createClass;
    [SerializeField] private Button _nextLevelButton;

    public void End()
    {
        _levelTimer._timerText.text = "0";
        _createClass.IsCreate = false;
        _nextLevelButton.gameObject.SetActive(true);
        PlayerPrefs.SetInt(SaveKeys.AllCounts, Counts.AllCounts);
        PlayerPrefs.Save();
    }
}
