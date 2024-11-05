using UnityEngine;
using UnityEngine.EventSystems;

public class Cat : MonoBehaviour, IPointerDownHandler 
{
    [SerializeField] private int _counts;
    private ClickDestroy _clickDestroy;
    private PointsManager _pointersManager;

    private void Awake()
    {
        _clickDestroy = FindObjectOfType<ClickDestroy>();
        _pointersManager = FindObjectOfType<PointsManager>();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        _clickDestroy.ClickOnCat(gameObject);
        _pointersManager.PointsAdd(_counts);
    }
}
