using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonCheck : MonoBehaviour, IPointerDownHandler, IPointerUpHandler 
{

    private void Start()
    {
        LeaderBoardController.instance.ShowScores();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        TimerController.instance.BeginTimer();
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        
        TimerController.instance.EndTimer();
        LeaderBoardController.instance.SubmitScore(TimerController.instance.getTimePlaying());
        LeaderBoardController.instance.ShowScores();
    }
    
    

}
