using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreeCatsCounter : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private TMP_Text _counterText;
    [SerializeField] private SpendPoints _spendPoints;
    [SerializeField] private int _counterNumber;
    [SerializeField] private FreeCatsAnimation _freeCatsAnimation;
    private Coroutine _coroutine;
    [HideInInspector] public int Counter;

    private void Start()
    {
        if (PlayerPrefs.HasKey(SaveKeys.FreeCatsCounter))
        {
            Counter = PlayerPrefs.GetInt(SaveKeys.FreeCatsCounter);
        }
        else
        {
            Counter = _counterNumber;
            PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, Counter);
            PlayerPrefs.Save();
        }
        _counterText.text = Counter.ToString();

        _freeCatsAnimation.Init();
    }

    private IEnumerator CountDecrease()
    {
        for (int i = Counter; _spendPoints.MinusPointsCount < i; i-- )
        {
            if (_spendPoints._allPoints == 0)
            {
                break;
            }

            Counter--;
            _freeCatsAnimation.ChangeNumbersOfCats();
            _counterText.text = Counter.ToString();

            yield return new WaitForSeconds(_spendPoints.waitTime);
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _coroutine = StartCoroutine(CountDecrease());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        PlayerPrefs.SetInt(SaveKeys.FreeCatsCounter, Counter);
        PlayerPrefs.Save();
        if (_coroutine != null) StopCoroutine(_coroutine);
    }
}
