using NaughtyAttributes;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private int _currentMaxLevel;
    [SerializeField] private int _allPoints;
    [SerializeField] private int _freePoints;

    [Button ("������� ��� ������")]
    private void OpenAllLevels()
    {
        PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, _currentMaxLevel);
        PlayerPrefs.Save();
    }

    [Button("������� ��� ������")]
    private void CloseAllLevels()
    {
        PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, 1);
        PlayerPrefs.Save();
    }

    [Button("�������� ��� ����")]
    private void ResetPoints()
    {
        PlayerPrefs.DeleteKey(SaveKeys.AllPoints);
        PlayerPrefs.Save();
    }

    [Button("�������� ��� ����������")]
    private void ResetAllSaves()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
    }

    [Button("���������� ���-�� ����� All")]
    private void SetAllPoints()
    {
        PlayerPrefs.SetInt(SaveKeys.AllPoints,_allPoints);
        PlayerPrefs.Save();
    }

    [Button("���������� ���-�� ����� Free")]
    private void SetFreePoints()
    {
        PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, _freePoints);
        PlayerPrefs.Save();
    }
}
