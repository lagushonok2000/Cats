using NaughtyAttributes;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private int _currentMaxLevel;
    [SerializeField] private int _expectedPoints;

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

    [Button("Установить кол-во очков")]
    private void SetPoints()
    {
        PlayerPrefs.SetInt(SaveKeys.AllPoints,_expectedPoints);
        PlayerPrefs.Save();
    }
}
