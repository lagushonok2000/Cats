using NaughtyAttributes;
using UnityEngine;

public class SavesManager : MonoBehaviour
{
    [SerializeField] private int _currentMaxLevel;
    [SerializeField] private int _expectedPoints;

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

    [Button("���������� ���-�� �����")]
    private void SetPoints()
    {
        PlayerPrefs.SetInt(SaveKeys.AllPoints,_expectedPoints);
        PlayerPrefs.Save();
    }
}
