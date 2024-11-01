using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChooseLevel : MonoBehaviour
{
    [SerializeField] private Button[] _buttons;

    private void SetLevel(int level)
    {
        Level.Current = level;
        SceneManager.LoadScene(1);
    }

    private void Start()
    {
        for (int i = 0; i < _buttons.Length; i++)
        {
            int j = i;
            _buttons[i].onClick.AddListener(() => SetLevel(j));
        }
    }

}
