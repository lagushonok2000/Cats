using System.Collections;
using TMPro;
using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] public EndGame _endGame;
    [SerializeField] public TMP_Text _timerText;
    [SerializeField] private LevelsSO _levelsSO;
    [SerializeField] private LevelsChanger _levelsChanger;

    private int _countSeconds;

    public void StartTimer(int seconds)
    {
        _countSeconds = seconds;
        StartCoroutine(Timer());
    }

    public IEnumerator Timer()
    {
        for (int i = _countSeconds; i > 0; i--)
        {
            _timerText.text = i.ToString();
            yield return new WaitForSeconds(1f);
        }
        _endGame.End();
    }
}
