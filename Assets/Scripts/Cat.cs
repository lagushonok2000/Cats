using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] private TMP_Text _pointsText;
    [SerializeField] private int _counts;
    private Animator _clickOnCatAnim;
    public float Probability;
    private ClickDestroy _clickDestroy;
    private PointsManager _pointersManager;
    private AudioManager _audioManager;

    private void Awake()
    {
        _clickDestroy = FindObjectOfType<ClickDestroy>();
        _pointersManager = FindObjectOfType<PointsManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _clickOnCatAnim = GetComponent<Animator>();
        if (_counts > 0) _pointsText.text = "+" + _counts.ToString();
        else _pointsText.text = _counts.ToString();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clickDestroy.ClickOnCat(gameObject);
        _pointersManager.PointsAdd(_counts);
        _clickOnCatAnim.SetTrigger("PointsAnim");
        if (_counts < 0)
        {
            _audioManager.ClicOnCatMinus();
        }
        else
        {
            _audioManager.ClickOnCatPlus();
        }
    }
}
