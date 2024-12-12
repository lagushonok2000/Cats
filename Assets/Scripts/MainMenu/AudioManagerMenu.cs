using UnityEngine;
using UnityEngine.UI;

public class AudioManagerMenu : MonoBehaviour
{
    [SerializeField] private AudioSource _buttonsSound;
    [SerializeField] private Button _button;

    private void Start()
    {
        
    }
    private void OnButtonClick()
    {
        _buttonsSound.Play();
    }
}
