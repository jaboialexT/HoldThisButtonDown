using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class IDController : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool gameStarted = false;
    public Animator animator;
    public InputField MemberID;
    public void OnPointerDown(PointerEventData eventData)
    {
        LeaderBoardController.instance.setMemberID(MemberID.text);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        if (MemberID.text != "")
        {
            gameStarted = true;
            animator.SetBool("Start", true);
            LeaderBoardController.instance.ShowScores();
            MemberID.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }



}