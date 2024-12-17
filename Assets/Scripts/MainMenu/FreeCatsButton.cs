using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class FreeCatsButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Action Up;
    public Action Down;

    public void OnPointerDown(PointerEventData eventData)
    {
        Down?.Invoke();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Up?.Invoke();
    }

   
}
