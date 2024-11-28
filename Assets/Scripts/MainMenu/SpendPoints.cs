using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpendPoints : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private LevelsSO _levelsSO;
    [SerializeField] private UpdateStartAllCounts _updateStartAllCounts;
    private Coroutine _coroutine;
    [HideInInspector] public int _allPoints;
    [HideInInspector] public int MinusPointsCount;
    [HideInInspector] public float waitTime;

    private void Start()
    {
        _allPoints = PlayerPrefs.GetInt(SaveKeys.AllPoints);
    }

    public IEnumerator Spend()
    {
        int startPoints = _allPoints;
        waitTime = _levelsSO.SpendTime;

        for (int i = startPoints; i > 0; i--)
        {
            
            
            _allPoints--;
            MinusPointsCount++;

            //if (waitTime > 0)
            //{
            //    waitTime -= 0.01f;
            //}

            _updateStartAllCounts.ÀllCountsText.text = _allPoints.ToString();
            yield return new WaitForSeconds(waitTime);


            if (_allPoints == 0)
            {
                break;
            }
        }

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _coroutine = StartCoroutine(Spend());
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (_coroutine != null) StopCoroutine(_coroutine); 
        PlayerPrefs.SetInt(SaveKeys.AllPoints,_allPoints);
        PlayerPrefs.Save();
    }
}
