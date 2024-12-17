using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour
{
    [SerializeField] private Button _quitButton;

    void Start()
    {
        _quitButton.onClick.AddListener(QuitGame);
    }

   private void QuitGame()
    {
        Application.Quit();
    }
}
