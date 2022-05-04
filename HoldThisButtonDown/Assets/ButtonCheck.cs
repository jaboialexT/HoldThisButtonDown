using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{
    public bool buttonPressed;

    public void OnPointerDown(PointerEventData eventData)
    {
        buttonPressed = true;
        TimerController.instance.BeginTimer();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        buttonPressed = false;
        TimerController.instance.EndTimer();
    }
    
    

}
