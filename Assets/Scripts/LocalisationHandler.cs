using UnityEngine;
using UnityEngine.UI;

public class LocalisationHandler : MonoBehaviour
{
    [SerializeField] private Button _localisationButton;
    [SerializeField] private LocalisationView[] _locView;

    private bool _languageEng;
    private int _languageIndex;

    private void Start()
    {
        if (Language.LanguageEnum == LanguageEnum.rus) _languageEng = true;
        else _languageEng = false;

        Change();
        _localisationButton.onClick.AddListener(Change);
    }

    private void Change()
    {
        ChangeIndexLanguage();
        for (int i = 0; i < _locView.Length; i++)
        {
            _locView[i].ChangeLanguage(_languageIndex);
        }
    }

    private void ChangeIndexLanguage()
    {
        _languageEng = !_languageEng;
        _languageIndex = _languageEng == false ? 0 : 1;

        if (_languageEng)
        {
            Language.LanguageEnum = LanguageEnum.eng;
        }
        else
        {
            Language.LanguageEnum = LanguageEnum.rus;
        }

    }
}
