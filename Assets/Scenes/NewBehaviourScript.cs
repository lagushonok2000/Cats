using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private Button _button;
    [SerializeField] private TMP_Text _text;

    private int _count;
    private string _key = "points";

    private void Start()
    {
        _count = PlayerPrefs.GetInt(_key);
        _text.text = _count.ToString();
        _button.onClick.AddListener(ClickButton);
    }

    private void ClickButton()
    {
        _count++;
        _text.text = _count.ToString();
    }
    private void OnApplicationQuit()
    {
        PlayerPrefs.SetInt(_key, _count);
        PlayerPrefs.Save();
    }
}
