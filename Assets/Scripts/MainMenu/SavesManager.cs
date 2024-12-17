using NaughtyAttributes;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private int _currentMaxLevel;
    [SerializeField] private int _allPoints;
    [SerializeField] private int _freePoints;

    [Button ("открыть все уровни")]
    private void OpenAllLevels()
    {
        PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, _currentMaxLevel);
        PlayerPrefs.Save();
    }

    [Button("закрыть все уровни")]
    private void CloseAllLevels()
    {
        PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, 1);
        PlayerPrefs.Save();
    }

    [Button("обнулить все очки")]
    private void ResetPoints()
    {
        PlayerPrefs.DeleteKey(SaveKeys.AllPoints);
        PlayerPrefs.Save();
    }

    [Button("обнулить все сохранения")]
    private void ResetAllSaves()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    [Button("Установить кол-во очков All")]
    private void SetAllPoints()
    {
        PlayerPrefs.SetInt(SaveKeys.AllPoints,_allPoints);
        PlayerPrefs.Save();
    }

    [Button("Установить кол-во очков Free")]
    private void SetFreePoints()
    {
        PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, _freePoints);
        PlayerPrefs.Save();
    }
}
