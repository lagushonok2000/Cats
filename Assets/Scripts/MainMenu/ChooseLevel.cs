using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private int _currentLevel;
    [SerializeField] private Button[] _buttons;

    private void Start()
    {
        _buttons[0].interactable = true;

        if (!PlayerPrefs.HasKey(SaveKeys.MaximumActiveLevel))
        {
            PlayerPrefs.SetInt(SaveKeys.MaximumActiveLevel, 1);
            PlayerPrefs.Save();
        }

        for (int i = 0; i < _buttons.Length; i++)
        {
            int j = i;
            _buttons[i].onClick.AddListener(() => SetLevel(j)); 
        }

        UpdateButtons();
    }

    private void SetLevel(int level)
    {
        Level.Current = level;
        SceneManager.LoadScene(1);
    }

    private void UpdateButtons()
    {
        int maxLevel = PlayerPrefs.GetInt(SaveKeys.MaximumActiveLevel);

        for (int i = 0; i < _buttons.Length; i++)
        {
            if (i + 1 <= maxLevel)
            {
                _buttons[i].interactable = true;
            }
            else
            {
                _buttons[i].interactable = false;
            }
        }
    }
}
